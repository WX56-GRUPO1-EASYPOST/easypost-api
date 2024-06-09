using easypost_api.Tickets.Domain.Model.ValueObjects;

namespace easypost_api.Tickets.Domain.Model.Commands;

public record CreateTicketCommand(
    string Title, string Description, ECategory Category,
    EPriority Priority);