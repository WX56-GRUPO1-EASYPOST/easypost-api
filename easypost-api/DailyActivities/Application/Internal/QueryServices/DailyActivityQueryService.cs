using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Model.Queries;
using easypost_api.DailyActivities.Domain.Repositories;
using easypost_api.DailyActivities.Domain.Services;

namespace easypost_api.DailyActivities.Application.Internal.QueryServices;

public class DailyActivityQueryService(
    IDailyActivityRepository dailyActivityRepository
    ): IDailyActivityQueryService
{
    public async Task<IEnumerable<DailyActivity?>> Handle(GetAllDailyActivitiesQuery query)
    {
        return await dailyActivityRepository.ListAsync();
    }

    public async Task<DailyActivity?> Handle(GetDailyActivityByIdQuery query)
    {
        return await dailyActivityRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<DailyActivity?>> Handle(GetDailyActivitiesByProjectIdQuery query)
    {
        return await dailyActivityRepository.FindByProjectIdAsync(query.ProjectId);
    }
}