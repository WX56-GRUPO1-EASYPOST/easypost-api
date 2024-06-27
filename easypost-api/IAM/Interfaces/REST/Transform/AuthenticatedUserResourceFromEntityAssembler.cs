using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Interfaces.REST.Resources;

namespace easypost_api.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, user.ProfileId, token);
    }
}