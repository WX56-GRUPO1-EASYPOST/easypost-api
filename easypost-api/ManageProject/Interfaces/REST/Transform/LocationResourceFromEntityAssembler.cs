using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class LocationResourceFromEntityAssembler
{
    public static LocationResource ToResourceFromEntity(Location entity)
    {
        return new LocationResource(
            entity.Id,
            entity.Department,
            entity.Province,
            entity.District,
            entity.Locality,
            entity.Address,
            entity.Reference);
    }
}