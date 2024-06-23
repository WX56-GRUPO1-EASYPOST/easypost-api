using easypost_api.Message.Interfaces.REST.Resources;

namespace easypost_api.Message.Interfaces.REST.Transform;

public static class MessageResourceFromEntityAssembler
{
    public static MessageResource ToResourceFromEntity(Domain.Model.Aggregates.Message entity)
    {
        return new MessageResource(entity.Id, entity.Subject, entity.EmailBody, entity.Recipient, entity.Sender, entity.SentTime);
    }
}