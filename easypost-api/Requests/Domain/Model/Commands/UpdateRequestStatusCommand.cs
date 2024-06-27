using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Domain.Model.Commands;

public record UpdateRequestStatusCommand(int RequestId, ERequestStatus Status);