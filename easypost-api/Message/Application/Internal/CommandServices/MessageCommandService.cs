using easypost_api.Message.Domain.Model.Commands;
using easypost_api.Message.Domain.Repositories;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Message.Application.Internal.CommandServices;

public class MessageCommandService(MessageRepository messageRepository,IUnitOfWork unitOfWork): Domain.Services.MessageCommandService
{
    public async Task<Domain.Model.Aggregates.Message?> Handle(CreateMessageCommand command)
    {
        var message = new Domain.Model.Aggregates.Message(command);
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