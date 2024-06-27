using easypost_api.ManageProject.Interfaces.ACL;

namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL.Services;

public class ExternalRequestProjectService(
    IProjectContextFacade projectContextFacade)
    :IExternalRequestProjectService
{
    public async Task<int?> CreateProject(string projectTitle, long budget, long partialBudget, int locationId, int companyProfileId)
    {
        var projectId = await projectContextFacade.CreateProject(projectTitle, budget, partialBudget, locationId, companyProfileId);
        return projectId;
    }
}