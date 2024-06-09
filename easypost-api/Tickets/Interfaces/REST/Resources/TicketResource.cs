namespace easypost_api.Tickets.Interfaces.REST.Resources;

public record TicketResource(string Title, string Description, string Category, string Priority,
    int ProfileId,string Status, string CreatedAt);