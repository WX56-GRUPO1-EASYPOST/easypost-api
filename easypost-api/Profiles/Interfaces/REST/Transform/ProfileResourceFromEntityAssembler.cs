using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Interfaces.REST.resources;

namespace easypost_api.Profiles.Interfaces.REST.Transform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id,entity.FullContact,entity.FullAddress,
            entity.FullDetails);
    }
}