using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Interfaces.REST.Resources;

namespace easypost_api.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username, user.Type.ToString());
    }
}