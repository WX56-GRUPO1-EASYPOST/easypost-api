using easypost_api.Tickets.Domain.Model.Commands;
using easypost_api.Tickets.Domain.Model.ValueObjects;

namespace easypost_api.Tickets.Domain.Model.Aggregates;

public class Ticket
{
    public int Id { get; }
    public string Title { get;}
    public string Description { get; }
    public ECategory Category { get; private set; }
    public EPriority Priority { get; private set; }
    public int ProfileId { get; private set; }
    public EStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastUpdate { get; private set; }

    public Ticket(CreateTicketCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
        this.Category = command.Category;
        this.Priority = command.Priority;
        this.ProfileId = command.ProfileId;
        this.Status = EStatus.InProgress;
        this.CreatedAt=DateTime.Now;
        this.LastUpdate = null;
    }
    
    public Ticket()
    {
        
    }

    public void ChangeStatus(EStatus status)
    {
        this.Status = status;
    }

    public void UpdateTicket()
    {
        this.LastUpdate = DateTime.Now;
    }
}