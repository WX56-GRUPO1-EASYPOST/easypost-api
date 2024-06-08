using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.IAM.Application.Internal.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserCommandService(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Handle(SignUpCommand command)
    {
        if (_userRepository.ExistsByUsername(command.Username))
        {
            throw new Exception($"Username {command.Username} already exists");
        }
        var user = new User(command.Username,command.Password, command.Type);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error ocurred while creating user: {e.Message}");
        }
    }

    public async Task<User> Handle(SignInCommand command)
    {
        var user = await _userRepository.FindByUsername(command.Username);
        if (user==null || user.Password!=command.Password)
        {
            throw new Exception("Invalid username or password");
        }

        return user;
    }
}