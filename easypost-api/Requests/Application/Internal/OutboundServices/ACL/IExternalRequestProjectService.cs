namespace easypost_api.Requests.Application.Internal.OutboundServices.ACL;

public interface IExternalRequestProjectService
{
    Task<int?> CreateProject(
        string projectTitle,
        long budget,
        long partialBudget,
        int locationId, 
        int companyProfileId
        );
}