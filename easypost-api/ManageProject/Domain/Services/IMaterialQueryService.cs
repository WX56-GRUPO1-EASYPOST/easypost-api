using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;

namespace easypost_api.ManageProject.Domain.Services;

public interface IMaterialQueryService
{
    Task<Material?> Handle(GetMaterialByIdQuery query);
    Task<Material?> Handle(GetMaterialByNameQuery query);
    Task<IEnumerable<Material>> Handle(GetAllMaterialsQuery query);

}