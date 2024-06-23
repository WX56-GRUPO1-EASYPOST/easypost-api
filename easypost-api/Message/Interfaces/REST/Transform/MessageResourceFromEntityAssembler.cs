using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Interfaces.REST.Resources;

namespace easypost_api.Message.Interfaces.REST.Transform;

public static class MessageResourceFromEntityAssembler
{
    public static MessageResource ToResourceFromEntity(MessageEntity entity)
    {
        return new MessageResource(entity.Id, entity.Text,
            entity.RecipientId, entity.SenderId, entity.SentTime.ToString("G"));
    }
}