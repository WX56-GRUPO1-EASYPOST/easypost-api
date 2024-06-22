using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Commands;

namespace easypost_api.Requests.Domain.Services;

public interface IRequestCommandService
{
    Task<Request?> Handle(CreateRequestCommand command);
    Task<Request?> Handle(CreateRequestByFormCommand command);
}