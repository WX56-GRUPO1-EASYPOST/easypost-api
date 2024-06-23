using easypost_api.Message.Domain.Model.Commands;
using easypost_api.Message.Interfaces.REST.Resources;

namespace easypost_api.Message.Interfaces.REST.Transform;

public static class CreateMessageCommandFromResourceAssembler
{
    public static CreateMessageCommand ToCommandFromResource(CreateMessageResource resource)
    {
        return new CreateMessageCommand(resource.Subject, resource.EmailBody, resource.RecipientId, resource.SenderId);
    }
}