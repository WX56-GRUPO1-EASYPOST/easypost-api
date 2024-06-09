using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Interfaces.REST.Resources;

namespace easypost_api.Tickets.Interfaces.REST.Transform;

public class TicketResourceFromEntityAssembler
{
    public static TicketResource ToResourceFromEntity(Ticket entity)
    {
        return new TicketResource(entity.Title,entity.Description,entity.Category.ToString(),
            entity.Priority.ToString(),entity.Status.ToString(),entity.CreatedAt.ToString("G"));
    }
}