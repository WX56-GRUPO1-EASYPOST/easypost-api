using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Interface.REST.Resources;

public record CreateRequestResource(string Description, RequestStatus Status, int ProjectId);