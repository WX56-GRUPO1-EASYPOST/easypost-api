using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Queries;
using easypost_api.Message.Domain.Repositories;

namespace easypost_api.Message.Application.Internal.QueryServices;

public class MessageQueryService(IMessageRepository messageRepository): Domain.Services.IMessageQueryService
{
    public async Task<MessageEntity?> Handle(GetMessageByIdQuery query)
    {
        return await messageRepository.FindByIdAsync(query.MessageId);
    }
}