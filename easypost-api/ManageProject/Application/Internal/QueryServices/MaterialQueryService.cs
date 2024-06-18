using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Application.Internal.QueryServices;

public class MaterialQueryService(IMaterialRepository materialRepository): IMaterialQueryService
{
    public async Task<Material?> Handle(GetMaterialByIdQuery query)
    {
        return await materialRepository.FindByIdAsync(query.Id);
    }

    public async Task<Material?> Handle(GetMaterialByNameQuery query)
    {
        return await materialRepository.FindByNameAsync(query.Name);
    }

    public async Task<IEnumerable<Material>> Handle(GetAllMaterialsQuery query)
    {
        return await materialRepository.ListAsync();
    }
}