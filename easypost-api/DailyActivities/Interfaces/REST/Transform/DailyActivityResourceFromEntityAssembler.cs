using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Interfaces.REST.Resources;

namespace easypost_api.DailyActivities.Interfaces.REST.Transform;

public static class DailyActivityResourceFromEntityAssembler
{
    public static DailyActivityResource ToResourceFromEntity(DailyActivity entity)
    {
        return new DailyActivityResource(
            entity.Id,
            entity.Description,
            entity.ProjectId,
            entity.Name
        );
    }
}