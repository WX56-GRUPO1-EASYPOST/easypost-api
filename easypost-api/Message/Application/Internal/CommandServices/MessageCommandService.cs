using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Commands;
using easypost_api.Message.Domain.Repositories;
using easypost_api.Message.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Message.Application.Internal.CommandServices;

public class MessageCommandService(IMessageRepository messageRepository,IUnitOfWork unitOfWork): IMessageCommandService
{
    public async Task<MessageEntity?> Handle(CreateMessageCommand command)
    {
        var message = new MessageEntity(command);
        try
        {
            await messageRepository.AddAsync(message);
            await unitOfWork.CompleteAsync();
            return message;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}