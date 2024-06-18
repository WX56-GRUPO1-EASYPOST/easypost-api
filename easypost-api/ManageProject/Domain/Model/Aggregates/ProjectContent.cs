using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.ValueObjects;

namespace easypost_api.ManageProject.Domain.Model.Aggregates;

public partial class Project: IPublishable
{
    public Project()
    {
        Title = string.Empty;
        AccessCode = 0;
        TotalBudget = 0;
        PartialBudget = 0;
        ConstructionPermits = new List<ConstructionPermit>();
        Status = EContentStatus.Draft;
    }
    
    public EContentStatus Status { get; private set; }
    
    public ICollection<ConstructionPermit> ConstructionPermits { get; private set; }

    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EContentStatus.ReadyToApprove))
            Status = EContentStatus.ReadyToApprove;
    }

    public void Approve()
    {
        if (HasAllAssetsWithStatus(EContentStatus.Approved))
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
    
    private bool HasAllAssetsWithStatus(EContentStatus status) => ConstructionPermits.All(asset => asset.Status == status);
    
    public void AddConstructionPermit(string title)
    {
        if (ExistsConstructionPermitByTitle(title)) return;
        ConstructionPermits.Add(new ConstructionPermit(title));
    }
    
    private bool ExistsConstructionPermit(ConstructionPermit constructionPermit) => ConstructionPermits.Any(permit => permit.Id == constructionPermit.Id);
    
    private bool ExistsConstructionPermitByTitle(string title) => ConstructionPermits.Any(permit => permit.Title == title);
    
    public void UpdatePartialBudget(long partialBudget)
    {
        PartialBudget = partialBudget;
    }
}