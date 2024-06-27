using easypost_api.Shared.Domain.Repositories;
using easypost_api.IAM.Application.Internal.OutboundServices;
using easypost_api.IAM.Application.Internal.OutboundServices.ACL;
using easypost_api.IAM.Application.Internal.OutboundServices.ACL.Services;
using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Domain.Model.ValueObjects;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;
using easypost_api.Profiles.Domain.Model.ValueObjects;

namespace easypost_api.IAM.Application.Internal.CommandServices;

/**
 * <summary>
 *     The user command service
 * </summary>
 * <remarks>
 *     This class is used to handle user commands
 * </remarks>
 */
public class UserCommandService(
    IUserRepository userRepository,
    IExternalProfileService externalProfileService,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork)
    : IUserCommandService
{
    /**
     * <summary>
     *     Handle sign in command
     * </summary>
     * <param name="command">The sign in command</param>
     * <returns>The authenticated user and the JWT token</returns>
     */
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }

    /**
     * <summary>
     *     Handle sign up command
     * </summary>
     * <param name="command">The sign up command</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");
        
        var hashedPassword = hashingService.HashPassword(command.Password);

        var profileId = await externalProfileService.CreateProfile(
            command.Name,
            command.Description,
            command.Ruc,
            command.Phone,
            command.Email,
            command.Department,
            command.District,
            command.Residential,
            command.Type
        );
        
        var user = new User(command.Username, hashedPassword, profileId);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }
}