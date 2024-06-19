using easypost_api.Shared.Domain.Repositories;
using easypost_api.Tickets.Domain.Model.Aggregates;

namespace easypost_api.Tickets.Domain.Repositories;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    
}