using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Model.ValueObjects;

namespace easypost_api.Requests.Domain.Model.Aggregates;

public partial class Request
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public RequestDescription Description { get; set; }
    public ERequestStatus Status { get; set; }
    public DateTime Deadline { get; set; }
    public int ClientId { get; set; }
    public Profile Client { get; set; }
    public int EnterpriseId { get; set; }
    public Profile Enterprise { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }

    public string DescriptionText => Description.DescriptionText;
    public Request()
    {
        this.Id = 0;
        this.ProjectId = 0;
        this.Description = new RequestDescription();
        this.Status = ERequestStatus.Pending;
    }
    public Request(int projectId, string requestDescription, ERequestStatus eRequestStatus
        , DateTime requestDate, string budget)
    {
        //this.Id = requestId;
        this.ProjectId = projectId;
        this.Description = new RequestDescription(requestDescription,budget);
        this.Status = eRequestStatus;
        this.Deadline = requestDate;
    }

    public Request(CreateRequestCommand command)
    {
        //this.Id = 0;
        this.ProjectId = command.ProjectId;
        this.Description = new RequestDescription(command.Description);
        this.Status = ERequestStatus.Pending;
        this.Deadline = DateTime.Now;
    }
    // Método para actualizar la descripción de la solicitud
    public void UpdateDescription(string newDescription)
    {
        this.Description = new RequestDescription(newDescription);
    }

    // Método para actualizar el estado de la solicitud
    public void UpdateStatus(ERequestStatus newStatus)
    {
        this.Status = newStatus;
    }

    // Método para aprobar la solicitud
    public void Approve()
    {
        this.Status = ERequestStatus.Approved;
    }

    // Método para rechazar la solicitud
    public void Reject()
    {
        this.Status = ERequestStatus.Rejected;
    }
}