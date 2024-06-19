using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectMaterialsQueryService
{
    Task<ProjectMaterials?> Handle(GetProjectMaterialByProjectIdAndMaterialIdQuery query);
    Task<IEnumerable<ProjectMaterials?>> Handle(GetProjectMaterialByProjectIdQuery query);
}