using easypost_api.ManageProject.Interfaces.REST.Transform;
using easypost_api.Profiles.Interfaces.REST.Transform;
using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Interface.REST.Resources;

namespace easypost_api.Requests.Interface.REST.Transform;

public static class RequestResourceFromEntityAssembler
{
    public static RequestResource ToResourceFromEntity(Request entity)
    {
        return new RequestResource(
            entity.Id, 
            entity.DescriptionText,
            entity.Status.ToString(),
            entity.ProjectId,
            entity.EnterpriseId,
            entity.ClientId,
            entity.Deadline.ToString("G"),
            entity.LocationId );
    }
}