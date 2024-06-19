using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Queries;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;

namespace easypost_api.IAM.Application.Internal.QueryServices;

public class UserQueryService:IUserQueryService
{
    private readonly IUserRepository _userRepository;

    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await _userRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await _userRepository.ListAsync();
    }
    
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await _userRepository.FindByUsername(query.Username);
    }
}