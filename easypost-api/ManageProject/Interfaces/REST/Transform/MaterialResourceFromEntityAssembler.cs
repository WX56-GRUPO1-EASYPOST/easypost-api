using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public static class MaterialResourceFromEntityAssembler
{
    public static MaterialResource ToResourceFromEntity(Material entity)
    {
        return new MaterialResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Cost
        );
    }
}