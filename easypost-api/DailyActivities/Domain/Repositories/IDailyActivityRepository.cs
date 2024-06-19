using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.DailyActivities.Domain.Repositories;

public interface IDailyActivityRepository: IBaseRepository<DailyActivity>
{
    Task<IEnumerable<DailyActivity>> FindByProjectIdAsync(int projectId);
}