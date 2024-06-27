using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Interface.REST.Resources;

namespace easypost_api.Requests.Interface.REST.Transform;

public static class CreateRequestByFormCommandFromResourceAssembler
{
    public static CreateRequestByFormCommand ToCommandFromResource(CreateRequestByFormResource resource)
    {
        return new CreateRequestByFormCommand(resource.Description, resource.Budget, resource.ClientId,
            resource.EnterpriseId, resource.Deadline, resource.Department, resource.Province, resource.District,
            resource.Address, resource.Locality, resource.Reference, resource.ProjectTitle, resource.PartialBudget);
    }
}