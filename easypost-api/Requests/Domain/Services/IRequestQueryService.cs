using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Queries;

namespace easypost_api.Requests.Domain.Services;

public interface IRequestQueryService
{
    Task<Request?> Handle(GetRequestByIdQuery query);
    Task<IEnumerable<Request>> Handle(GetAllRequestsQuery query);
}