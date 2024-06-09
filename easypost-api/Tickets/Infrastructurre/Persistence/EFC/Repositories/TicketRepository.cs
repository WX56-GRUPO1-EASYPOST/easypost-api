using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Domain.Repositories;

namespace easypost_api.Tickets.Infrastructurre.Persistence.EFC.Repositories;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    private readonly AppDbContext _context;
    public TicketRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}