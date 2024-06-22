using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Interface.ACL;

public interface IRequestsContextFacade
{
    Task<int> CreateRequest(string description, int projectId, int enterpriseId,
        int clientId, int locationId, string budget, DateTime deadline);
}