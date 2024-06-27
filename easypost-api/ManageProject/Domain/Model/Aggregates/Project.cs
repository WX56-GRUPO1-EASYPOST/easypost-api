using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Aggregates;

namespace easypost_api.ManageProject.Domain.Model.Aggregates;

public partial class Project
{
    public Project(
        string title,
        int accessCode,
        long totalBudget, 
        long partialBudget, 
        int locationId,
        int companyProfileId
        ): this()
    {
        Title = title;
        AccessCode = accessCode;
        TotalBudget = totalBudget;
        PartialBudget = partialBudget;
        LocationId = locationId;
        CompanyProfileId = companyProfileId;
    }

    public int Id { get; }
    public string Title { get; private set; }

    public int AccessCode { get; private set; }
    
    public int CompanyProfileId { get; private set; }
    public Profile Profile { get; private set; }
    
    public long TotalBudget { get; private set; }
    
    public long PartialBudget { get; private set; }
    
    public Location Location { get; internal set; }
    
    public int LocationId { get; private set; }    

    public ICollection<ProjectMaterials> ProjectMaterials { get; }

    public ICollection<Request> Requests { get; set; }
}