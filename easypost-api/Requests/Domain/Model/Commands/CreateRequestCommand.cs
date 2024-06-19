using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Domain.Model.Commands;

public record CreateRequestCommand(string Description, RequestStatus Status,int ProjectId)
{
}