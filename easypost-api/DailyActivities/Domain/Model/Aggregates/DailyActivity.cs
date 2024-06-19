using easypost_api.ManageProject.Domain.Model.Aggregates;

namespace easypost_api.DailyActivities.Domain.Model.Aggregates;

public partial class DailyActivity
{
    public DailyActivity(string description, int projectId, string name): this()
    {
        Name = name;
        Description = description;
        ProjectId = projectId;
    }

    public int Id { get; }
    public string Description { get; private set; }
    
    public string Name { get; private set; }
    
    public int ProjectId { get; private set; }
    
    public Project Project { get; internal set; }
}