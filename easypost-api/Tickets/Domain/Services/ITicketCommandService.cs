using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Domain.Model.Commands;

namespace easypost_api.Tickets.Domain.Services;

public interface ITicketCommandService
{
    Task<Ticket?> Handle(CreateTicketCommand command);
}