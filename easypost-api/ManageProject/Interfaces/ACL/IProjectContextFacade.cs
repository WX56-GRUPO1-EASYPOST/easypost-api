using easypost_api.ManageProject.Domain.Model.Aggregates;

namespace easypost_api.ManageProject.Interfaces.ACL;

public interface IProjectContextFacade
{
    Task<int?> CreateProject(string title, long totalBudget, long partialBudget, int locationId, int companyProfileId);
    Task<Project?> GetProjectById(int projectId);
}