using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Interfaces.ACL.Services;

public class ProjectContextFacade(IProjectCommandService projectCommandService,
    IProjectQueryService projectQueryService):IProjectContextFacade
{
    public async Task<int?> CreateProject(
        string title, 
        long totalBudget, 
        long partialBudget, 
        int locationId,
        int companyProfileId
        )
    {
        var command = new CreateProjectCommand(title, totalBudget, partialBudget, locationId, companyProfileId);
        var project = await projectCommandService.Handle(command);
        return project?.Id ?? 0;
    }

    public async Task<Project?> GetProjectById(int projectId)
    {
        var query = new GetProjectsByIdQuery(projectId);
        var project = await projectQueryService.Handle(query);
        return project ?? null;
    }
}