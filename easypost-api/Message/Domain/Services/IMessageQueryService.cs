using easypost_api.Message.Domain.Model.Queries;

namespace easypost_api.Message.Domain.Services;

public interface IMessageQueryService
{
    Task<Model.Aggregates.MessageEntity?> Handle(GetMessageByIdQuery query);
}