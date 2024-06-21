using easypost_api.IAM.Application.Internal.OutboundServices;
using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;
using easypost_api.Profiles.Interfaces.ACL;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.IAM.Application.Internal.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProfilesContextFacade _profilesContextFacade;
    private readonly ITokenService _tokenService;
    private readonly IHashingService _hashingService; 

    public UserCommandService(IUnitOfWork unitOfWork, IUserRepository userRepository,
        IProfilesContextFacade profilesContextFacade, ITokenService tokenService,
        IHashingService hashingService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _profilesContextFacade = profilesContextFacade;
        _tokenService = tokenService;
        _hashingService = hashingService;
    }

    public async Task Handle(SignUpCommand command)
    {
        if (_userRepository.ExistsByUsername(command.Username))
        {
            throw new Exception($"Username {command.Username} already exists");
        }

        var hashedPassword = _hashingService.HashPassword(command.Password);
        var user = new User(command.Username,hashedPassword, command.Type);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            
            await _profilesContextFacade.CreateProfileForUser(user.Username, "description",
                "ruc", "telefono", "correo", "departamento",
                "distrito", "residencial", user.Id);
        }
        catch (Exception e)
        {
            throw new Exception($"An error ocurred while creating user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await _userRepository.FindByUsername(command.Username);
        if (user==null || !_hashingService.VerifyPassword(command.Password,user.Password))
        {
            throw new Exception("Invalid username or password");
        }

        var token = _tokenService.GenerateToken(user);
        return (user,token);
    }
}