using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Queries;
using easypost_api.Message.Domain.Repositories;
using easypost_api.Message.Domain.Services;

namespace easypost_api.Message.Application.Internal.QueryServices;

public class MessageQueryService(IMessageRepository messageRepository): IMessageQueryService
{
    public async Task<MessageEntity?> Handle(GetMessageByIdQuery query)
    {
        return await messageRepository.FindByIdAsync(query.MessageId);
    }

    public async Task<IEnumerable<MessageEntity>> Handle(GetAllMessagesByRecipientAndSenderIdQuery query)
    {
        return await messageRepository.FindAllByRecipientAndSenderId(query.RecipientId,query.SenderId);
    }
}