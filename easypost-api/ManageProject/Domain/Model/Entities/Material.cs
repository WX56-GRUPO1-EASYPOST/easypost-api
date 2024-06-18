namespace easypost_api.ManageProject.Domain.Model.Entities;

public class Material
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Cost { get; private set; }
    
    public ICollection<ProjectMaterials> ProjectMaterials { get; }
    
    public Material(string name, string description, int cost)
    {
        Name = name;
        Description = description;
        Cost = cost;
    }
    
    public void Update(string name, string description, int cost)
    {
        Name = name;
        Description = description;
        Cost = cost;
    }
}