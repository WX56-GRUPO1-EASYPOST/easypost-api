using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.ValueObjects;

namespace easypost_api.ManageProject.Domain.Model.Aggregates;

public partial class Projects: IPublishable
{
    public Projects()
    {
        Title = string.Empty;
        AccesCode = string.Empty;
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
    
    public void AddConstructionPermit(ConstructionPermit constructionPermit)
    {
        if (ExistsConstructionPermit(constructionPermit)) return;
        ConstructionPermits.Add(constructionPermit);
    }
    
    private bool ExistsConstructionPermit(ConstructionPermit constructionPermit) => ConstructionPermits.Any(ConstructionPermit => ConstructionPermit.Id == constructionPermit.Id);
    
    public void updatePartialBudget(long partialBudget)
    {
        PartialBudget = partialBudget;
    }
}