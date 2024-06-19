using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Domain.Repositories;

public interface IProjectMaterialRepository: IBaseRepository<ProjectMaterials>
{
    Task<ProjectMaterials?> FindByProjectIdAndMaterialIdAsync(int projectId, int materialId);
    Task<IEnumerable<ProjectMaterials?>> FindByProjectIdAsync(int projectId);
}