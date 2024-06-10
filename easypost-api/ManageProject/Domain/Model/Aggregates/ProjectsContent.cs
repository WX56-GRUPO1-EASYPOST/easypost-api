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
        throw new NotImplementedException();
    }

    public void Approve()
    {
        throw new NotImplementedException();
    }

    public void Reject()
    {
        throw new NotImplementedException();
    }

    public void ReturnToEdit()
    {
        throw new NotImplementedException();
    }
}