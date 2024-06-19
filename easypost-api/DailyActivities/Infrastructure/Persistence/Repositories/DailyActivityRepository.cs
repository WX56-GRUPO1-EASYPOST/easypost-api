using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.DailyActivities.Infrastructure.Persistence.Repositories;

public class DailyActivityRepository(
    AppDbContext context
): BaseRepository<DailyActivity>(context), IDailyActivityRepository
{
    public async Task<IEnumerable<DailyActivity>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<DailyActivity>()
            .Where(dailyActivity => dailyActivity.ProjectId == projectId)
            .ToListAsync();
    }
}