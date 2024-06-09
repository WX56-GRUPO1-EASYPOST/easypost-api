using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Interface.REST.Resources;

namespace easypost_api.Requests.Interface.REST.Transform;

public class CreateRequestCommandFromResourceAssembler
{
    public static CreateRequestCommand ToCommandFromResource(CreateRequestResource resource)
    {
        return new CreateRequestCommand(resource.Description, resource.Status, resource.ProjectId);
    }
}