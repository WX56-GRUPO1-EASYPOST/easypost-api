using easypost_api.ManageProject.Interfaces.ACL;
using easypost_api.Profiles.Interfaces.ACL;
using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Queries;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Requests.Domain.Services;

namespace easypost_api.Requests.Application.Internal.QueryServices;

public class RequestQueryService : IRequestQueryService
{
    private readonly IRequestRepository _requestRepository;

    public RequestQueryService(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }
    
    public async Task<Request?> Handle(GetRequestByIdQuery query)
    {
        return await _requestRepository.FindByIdAsync(query.RequestId);
    }

    public async Task<IEnumerable<Request>> Handle(GetAllRequestsQuery query)
    {
        return await _requestRepository.ListAsync();
    }

    public async Task<IEnumerable<Request>> Handle(GetAllRequestsByEnterpriseIdAndStatusQuery query)
    {
        return await _requestRepository.FindAllByEnterpriseIdAndStatus(query.EnterpriseId, query.Status);
    }

    public async Task<IEnumerable<Request>> Handle(GetAllRequestsByClientIdAndStatusQuery query)
    {
        return await _requestRepository.FindAllByClientIdAndStatus(query.ClientId, query.Status);
    }
}