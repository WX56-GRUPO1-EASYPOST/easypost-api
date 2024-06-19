using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Poles.Infrastructure.Persistence.EFC.Repositories;

public class PoleRepository(
    AppDbContext context
    ): BaseRepository<Pole>(context), IPoleRepository
{
    public new async Task<Pole?> FindByIdAsync(int id) =>
        await Context.Set<Pole>()
            .Include(t => t.GeoReference)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Pole>> ListAsync()
    {
        return await Context.Set<Pole>()
            .Include(pole => pole.GeoReference)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Pole>> FindByGeoReferenceIdAsync(int geoReferenceId)
    {
        return await Context.Set<Pole>()
            .Include(pole => pole.GeoReference)
            .Where(pole => pole.GeoReferenceId == geoReferenceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Pole>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<Pole>()
            .Include(pole => pole.GeoReference)
            .Where(pole => pole.ProjectId == projectId)
            .ToListAsync();
    }
}