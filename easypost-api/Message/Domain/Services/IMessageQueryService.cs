using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Queries;

namespace easypost_api.Message.Domain.Services;

public interface IMessageQueryService
{
    Task<MessageEntity?> Handle(GetMessageByIdQuery query);
    Task<IEnumerable<MessageEntity>> Handle(GetAllMessagesByRecipientAndSenderIdQuery query);

}