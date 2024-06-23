using easypost_api.Message.Domain.Model.Commands;

namespace easypost_api.Message.Domain.Services;

public interface MessageCommandService
{
    Task<Model.Aggregates.Message?> Handle(CreateMessageCommand command);
}