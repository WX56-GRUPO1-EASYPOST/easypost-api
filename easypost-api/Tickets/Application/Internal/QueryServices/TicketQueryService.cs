using easypost_api.Shared.Domain.Repositories;
using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Domain.Model.Queries;
using easypost_api.Tickets.Domain.Repositories;
using easypost_api.Tickets.Domain.Services;

namespace easypost_api.Tickets.Application.Internal.QueryServices;

public class TicketQueryService : ITicketQueryService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TicketQueryService(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Ticket?> Handle(GetTicketByIdQuery query)
    {
        return await _ticketRepository.FindByIdAsync(query.Id);
    }
}