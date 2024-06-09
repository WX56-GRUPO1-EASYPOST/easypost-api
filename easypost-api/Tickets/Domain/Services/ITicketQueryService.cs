using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Domain.Model.Queries;

namespace easypost_api.Tickets.Domain.Services;

public interface ITicketQueryService
{
    Task<Ticket?> Handle(GetTicketByIdQuery query);
}