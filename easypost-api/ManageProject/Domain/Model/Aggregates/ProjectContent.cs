using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.ValueObjects;
using easypost_api.Poles.Domain.Model.Aggregates;

namespace easypost_api.ManageProject.Domain.Model.Aggregates;

public partial class Project
{
    public Project()
    {
        Title = string.Empty;
        AccessCode = 0;
        TotalBudget = 0;
        PartialBudget = 0;
        ConstructionPermits = new List<ConstructionPermit>();
        Poles = new List<Pole>();
        DailyActivities = new List<DailyActivity>();
        Status = EProjectStatus.WaitingForPermits;
    }
    
    public EProjectStatus Status { get; private set; }
    
    public ICollection<Pole> Poles { get; private set; }
    
    public ICollection<DailyActivity> DailyActivities { get; private set; }
    
    public ICollection<ConstructionPermit> ConstructionPermits { get; private set; }

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