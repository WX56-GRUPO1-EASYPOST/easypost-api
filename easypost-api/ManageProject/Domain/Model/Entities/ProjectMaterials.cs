using easypost_api.ManageProject.Domain.Model.Aggregates;

namespace easypost_api.ManageProject.Domain.Model.Entities;

public partial class ProjectMaterials
{
    public ProjectMaterials(int projectId, int materialId, int amount)
    {
        ProjectId = projectId;
        MaterialId = materialId;
        Amount = amount;
    }

    public int ProjectId { get; set; }
    
    public Project Project { get; set; }
    
    public int MaterialId { get; set; }
    
    public Material Material { get; set; }
    
    public int Amount { get; set; }
    
    public void UpdateAmount(int amount)
    {
        Amount = amount;
    }
}