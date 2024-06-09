using easypost_api.Tickets.Domain.Model.ValueObjects;

namespace easypost_api.Tickets.Interfaces.REST.Resources;

public record CreateTicketResource(
    string Title, string Description, ECategory Category,
    EPriority Priority, int ProfileId);