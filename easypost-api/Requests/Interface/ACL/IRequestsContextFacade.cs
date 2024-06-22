using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Interface.ACL;

public interface IRequestsContextFacade
{
    Task<int> CreateRequest(string description, ERequestStatus status, int projectId);
}