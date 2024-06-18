using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Domain.Repositories;

public interface IMaterialRepository: IBaseRepository<Material>
{
    Task<Material?> FindByNameAsync(string name);
}