using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;

public class ProjectMaterialsRepository(AppDbContext context):BaseRepository<ProjectMaterials>(context), IProjectMaterialRepository
{
    public async Task<ProjectMaterials?> FindByProjectIdAndMaterialIdAsync(int projectId, int materialId)
    {
        return await Context.Set<ProjectMaterials>()
            .Where(projectMaterials => projectMaterials.ProjectId == projectId && projectMaterials.MaterialId == materialId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProjectMaterials?>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<ProjectMaterials>()
            .Where(projectMaterials => projectMaterials.ProjectId == projectId)
            .ToListAsync();
    }
}