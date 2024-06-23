using easypost_api.Message.Domain.Model.Queries;
using easypost_api.Message.Domain.Repositories;

namespace easypost_api.Message.Application.Internal.QueryServices;

public class MessageQueryService(MessageRepository messageRepository): Domain.Services.MessageQueryService
{
    public async Task<Domain.Model.Aggregates.Message?> Handle(GetMessageByIdQuery query)
    {
        return await messageRepository.FindByIdAsync(query.MessageId);
    }
}