using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Interface.REST.Resources;

namespace easypost_api.Requests.Interface.REST.Transform;

public class RequestResourceFromEntityAssembler
{
    public static RequestResource ToResourceFromEntity(Request entity)
    {
        return new RequestResource(entity.Id, entity.DescriptionText, entity.Status.ToString(), entity.ProjectId);
    }
}