using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Model.Queries;

namespace easypost_api.DailyActivities.Domain.Services;

public interface IDailyActivityQueryService
{
    Task<IEnumerable<DailyActivity?>> Handle(GetAllDailyActivitiesQuery query);
    Task<DailyActivity?> Handle(GetDailyActivityByIdQuery query);
    Task<IEnumerable<DailyActivity?>> Handle(GetDailyActivitiesByProjectIdQuery query);
}