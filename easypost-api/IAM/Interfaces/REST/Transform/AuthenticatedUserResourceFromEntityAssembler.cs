using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Interfaces.REST.Resources;

namespace easypost_api.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user)
    {
        return new AuthenticatedUserResource(user.Id, user.Username,user.Type.ToString());
    }
}