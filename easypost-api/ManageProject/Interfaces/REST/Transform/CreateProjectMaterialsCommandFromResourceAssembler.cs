using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class CreateProjectMaterialsCommandFromResourceAssembler
{
    public static CreateProjectMaterialCommand ToCommandFromResource(CreateProjectMaterialsResource resource)
    {
        return new CreateProjectMaterialCommand(
            resource.MaterialId,
            resource.ProjectId,
            resource.Amount
        );
    }
}