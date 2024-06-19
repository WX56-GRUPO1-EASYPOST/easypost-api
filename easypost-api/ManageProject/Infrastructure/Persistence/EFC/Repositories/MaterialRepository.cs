using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;

public class MaterialRepository(AppDbContext context) : BaseRepository<Material>(context), IMaterialRepository
{
    public async Task<Material?> FindByNameAsync(string name)
    {
        return await Context.Set<Material>()
            .Where(material => material.Name == name)
            .FirstOrDefaultAsync();
    }
}
