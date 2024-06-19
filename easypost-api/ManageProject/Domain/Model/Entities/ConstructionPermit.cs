using easypost_api.ManageProject.Domain.Model.ValueObjects;

namespace easypost_api.ManageProject.Domain.Model.Entities;

public partial class ConstructionPermit: IPublishable
{
    public int Id { get; }
    
    public string Title { get; private set; }
    public EContentStatus Status { get; protected set; }
    
    public ConstructionPermit(string title)
    {
        Title = title;
        Status = EContentStatus.Draft;
    }
    
    public void SendToApproval()
    {
        Status = EContentStatus.ReadyToApprove;
    }

    public void Approve()
    {
        Status = EContentStatus.Approved;
    }

    public void Reject()
    {
        Status = EContentStatus.Rejected;
    }

    public void ReturnToEdit()
    {
        Status = EContentStatus.Draft;
    }
    
    public virtual object GetContent()
    {
        return string.Empty;
    }
}