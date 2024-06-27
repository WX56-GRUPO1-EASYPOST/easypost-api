using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public static class ProjectMaterialsResourceFromEntityAssembler
{
    public static ProjectMaterialResource ToResourceFromEntity(ProjectMaterials entity)
    {
        return new ProjectMaterialResource(
            entity.ProjectId,
            entity.MaterialId,
            entity.Amount
        );
    }
}