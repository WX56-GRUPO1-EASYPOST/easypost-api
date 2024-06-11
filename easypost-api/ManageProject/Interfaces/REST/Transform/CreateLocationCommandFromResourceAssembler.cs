using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class CreateLocationCommandFromResourceAssembler
{
    public static CreateLocationCommand ToCommandFromResource(CreateLocationResource resource)
    {
        return new CreateLocationCommand(
            resource.Department, 
            resource.Province, 
            resource.District, 
            resource.Locality, 
            resource.Address,
            resource.Reference);
    }
}