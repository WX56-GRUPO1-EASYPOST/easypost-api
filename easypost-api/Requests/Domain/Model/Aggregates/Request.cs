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
    public Project Project { get; internal set; }
    public RequestDescription Description { get; set; }
    public ERequestStatus Status { get; set; }
    public DateTime Deadline { get; set; }
    public int ClientId { get; set; }
    public Profile Client { get; internal set; }
    public int EnterpriseId { get; set; }
    public Profile Enterprise { get; internal set; }
    public int LocationId { get; set; }
    public Location Location { get; internal set; }

    public string DescriptionText => Description.DescriptionText;
    public Request()
    {
    }
    public Request(int projectId, string requestDescription, string budget, ERequestStatus status
        , DateTime deadline, int clientId, int enterpriseId, int locationId )
    {
        this.ProjectId = projectId;
        this.Description = new RequestDescription(requestDescription,budget);
        this.Status = status;
        this.Deadline = deadline;
        this.EnterpriseId = enterpriseId;
        this.ClientId = clientId;
        this.LocationId = locationId;
    }

    public Request(CreateRequestCommand command)
    {
        this.ProjectId = command.ProjectId;
        this.Description = new RequestDescription(command.Description,command.Budget);
        this.Status = ERequestStatus.Pending;
        this.Deadline = command.Deadline;
        this.LocationId = command.LocationId;
        this.ClientId = command.ClientProfileId;
        this.EnterpriseId = command.CompanyProfileId;
    }
    // Método para actualizar la descripción de la solicitud
    public void UpdateDescription(string newDescription,string budget)
    {
        this.Description = new RequestDescription(newDescription,budget);
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