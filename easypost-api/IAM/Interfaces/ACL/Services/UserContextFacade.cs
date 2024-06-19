using easypost_api.IAM.Domain.Model.Queries;
using easypost_api.IAM.Domain.Services;

namespace easypost_api.IAM.Interfaces.ACL.Services;

public class UserContextFacade(IUserQueryService userQueryService):IUserContextFacade
{
    public async Task<bool> ExistsUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return false;
        return true;
    }
}