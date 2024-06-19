using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class UpdateProjectMaterialsCommandFromResource
{
    public static UpdateAmountMaterialCommand ToCommandFromResource(UpdateProjectMaterialsResource resource)
    {
        return new UpdateAmountMaterialCommand(
            resource.MaterialId,
            resource.ProjectId,
            resource.Amount
        );
    }
}