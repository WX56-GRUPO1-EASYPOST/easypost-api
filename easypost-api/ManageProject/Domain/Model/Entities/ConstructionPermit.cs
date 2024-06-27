using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.ValueObjects;

namespace easypost_api.ManageProject.Domain.Model.Entities;

public partial class ConstructionPermit(string title) 
{
    public int Id { get; }
    
    public string Title { get; private set; } = title;
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public EPermitsStatus Status { get; set; } = EPermitsStatus.ReadyToSend;
    
    public void SetPermitSent() => Status = EPermitsStatus.Sent;
    
    public void SetPermitApproved() => Status = EPermitsStatus.Approved;
    
    public void SetPermitRejected() => Status = EPermitsStatus.Rejected;
    
}