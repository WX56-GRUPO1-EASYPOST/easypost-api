using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Domain.Model.Queries;

public record GetAllRequestsByClientIdAndStatusQuery(int ClientId, ERequestStatus Status);