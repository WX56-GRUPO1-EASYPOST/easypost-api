using easypost_api.Tickets.Domain.Model.Commands;
using easypost_api.Tickets.Interfaces.REST.Resources;

namespace easypost_api.Tickets.Interfaces.REST.Transform;

public class CreateTicketCommandFromResourceAssembler
{
    public static CreateTicketCommand ToCommandFromResource(CreateTicketResource resource)
    {
        return new CreateTicketCommand(resource.Title,resource.Description,resource.Category,
            resource.Priority);
    }
}