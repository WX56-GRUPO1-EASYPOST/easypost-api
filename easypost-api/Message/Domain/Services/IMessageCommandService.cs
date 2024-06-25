using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Commands;

namespace easypost_api.Message.Domain.Services;

public interface IMessageCommandService
{
    Task<MessageEntity?> Handle(CreateMessageCommand command);
}