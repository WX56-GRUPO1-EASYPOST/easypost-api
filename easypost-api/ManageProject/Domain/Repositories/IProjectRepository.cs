using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Domain.Repositories;

public interface IProjectRepository: IBaseRepository<Project>
{
    Task<IEnumerable<Project>> FindByLocationIdAsync(int locationId);
    Task<Project?> FindByAccessCodeAsync(int accessCode);
}