using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class CreateMaterialCommandFromResourceAssembler
{
    public static CreateMaterialCommand ToCommandFromResource(CreateMaterialResource resource)
    {
        return new CreateMaterialCommand(
            resource.Name,
            resource.Description,
            resource.Cost
        );
    }
}