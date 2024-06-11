using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;

public class ProjectRepository(AppDbContext context): BaseRepository<Projects>(context), IProjectRepository
{
    public new async Task<Projects?> FindByIdAsync(int id)
    {
        return await Context.Set<Projects>()
            .Include(project => project.Location)
            .Where(project => project.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public new async Task<IEnumerable<Projects>> ListAsync()
    {
        return await Context.Set<Projects>()
            .Include(project => project.Location)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Projects>> FindByLocationIdAsync(int locationId)
    {
        return await Context.Set<Projects>()
            .Include(project => project.Location)
            .Where(project => project.LocationId == locationId)
            .ToListAsync();
    }
}