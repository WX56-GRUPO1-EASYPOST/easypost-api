using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Application.Internal.QueryServices;

public class ProjectMaterialsQueryService(IProjectMaterialRepository projectMaterialRepository): IProjectMaterialsQueryService
{
    public async Task<ProjectMaterials?> Handle(GetProjectMaterialByProjectIdAndMaterialIdQuery query)
    {
        return await projectMaterialRepository.FindByProjectIdAndMaterialIdAsync(query.ProjectId, query.MaterialId);
    }

    public async Task<IEnumerable<ProjectMaterials?>> Handle(GetProjectMaterialByProjectIdQuery query)
    {
        return await projectMaterialRepository.FindByProjectIdAsync(query.ProjectId);
    }
}