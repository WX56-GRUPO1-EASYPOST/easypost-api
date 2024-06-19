using easypost_api.Shared.Domain.Repositories;
using easypost_api.Tickets.Domain.Model.Aggregates;
using easypost_api.Tickets.Domain.Model.Commands;
using easypost_api.Tickets.Domain.Repositories;
using easypost_api.Tickets.Domain.Services;

namespace easypost_api.Tickets.Application.Internal.CommandServices;

public class TicketCommandService : ITicketCommandService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TicketCommandService(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Ticket?> Handle(CreateTicketCommand command)
    {
        var ticket = new Ticket(command);
        try
        {
            await _ticketRepository.AddAsync(ticket);
            await _unitOfWork.CompleteAsync();
            return ticket;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}