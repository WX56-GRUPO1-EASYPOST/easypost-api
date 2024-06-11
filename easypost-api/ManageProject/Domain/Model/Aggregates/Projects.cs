using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Domain.Model.Aggregates;

public partial class Projects
{
    public Projects(
        string title, 
        string accesCode, 
        long totalBudget, 
        long partialBudget, 
        int locationId
        ): this()
    {
        Title = title;
        AccessCode = accesCode;
        TotalBudget = totalBudget;
        PartialBudget = partialBudget;
        LocationId = locationId;
    }

    public int Id { get; }
    public string Title { get; private set; }

    public string AccessCode { get; private set; }
    
    public long TotalBudget { get; private set; }
    
    public long PartialBudget { get; private set; }
    
    public Location Location { get; internal set; }
    
    public int LocationId { get; private set; }    
}