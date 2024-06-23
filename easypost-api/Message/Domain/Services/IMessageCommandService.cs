using easypost_api.Message.Domain.Model.Commands;

namespace easypost_api.Message.Domain.Services;

public interface IMessageCommandService
{
    Task<Model.Aggregates.MessageEntity?> Handle(CreateMessageCommand command);
}