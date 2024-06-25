using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.ValueObjects;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Requests.Domain.Repositories;

public interface IRequestRepository: IBaseRepository<Request>
{
    Task<IEnumerable<Request>> FindAllByEnterpriseIdAndStatus(int enterpriseId, ERequestStatus status);
    Task<IEnumerable<Request>> FindAllByClientIdAndStatus(int clientId, ERequestStatus status);
}