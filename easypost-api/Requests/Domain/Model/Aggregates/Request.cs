using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Domain.Model.Aggregates;

public class Request
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public RequestDescription Description { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime Date { get; set; }
    
    public string DescriptionText => Description.DescriptionText();
    public Request()
    {
        this.Id = 0;
        this.ProjectId = 0;
        this.Description = new RequestDescription();
        this.Status = RequestStatus.PENDING;
    }
    public Request(int requestId, int projectId, string requestDescription, RequestStatus requestStatus, DateTime requestDate)
    {
        this.Id = requestId;
        this.ProjectId = projectId;
        this.Description = new RequestDescription(requestDescription);
        this.Status = requestStatus;
        this.Date = requestDate;
    }

    public Request(CreateRequestCommand command)
    {
        this.Id = 0;
        this.ProjectId = command.ProjectId;
        this.Description = new RequestDescription(command.Description);
        this.Status = RequestStatus.PENDING;
        this.Date = DateTime.Now;
    }
    // Método para actualizar la descripción de la solicitud
    public void UpdateDescription(string newDescription)
    {
        this.Description = new RequestDescription(newDescription);
    }

    // Método para actualizar el estado de la solicitud
    public void UpdateStatus(RequestStatus newStatus)
    {
        this.Status = newStatus;
    }

    // Método para aprobar la solicitud
    public void Approve()
    {
        this.Status = RequestStatus.APROVED;
    }

    // Método para rechazar la solicitud
    public void Reject()
    {
        this.Status = RequestStatus.REJECTED;
    }
}