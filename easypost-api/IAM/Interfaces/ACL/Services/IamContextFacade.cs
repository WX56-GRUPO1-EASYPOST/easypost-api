using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Domain.Model.Queries;
using easypost_api.IAM.Domain.Services;

namespace easypost_api.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(
        string username, 
        string password,
        string type,
        string name, 
        string description, 
        string ruc, 
        string phone, 
        string email, 
        string department, 
        string district, 
        string residential
        )
    {
        var signUpCommand = new SignUpCommand(
            username, 
            password,
            type, 
            name, 
            description, 
            ruc, 
            phone, 
            email, 
            department, 
            district, 
            residential
            );
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }

    public async Task<bool> UserExistsByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result != null;
    }

}