using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class ProjectMaterialsResourceFromEntityAssembler
{
    public static ProjectMaterials ToResourceFromEntity(ProjectMaterials entity)
    {
        return new ProjectMaterials(
            entity.MaterialId,
            entity.ProjectId,
            entity.Amount
        );
    }
}