using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Entities;

namespace easypost_api.Poles.Domain.Model.Aggregates;

public partial class Pole
{
    public Pole(string description, int projectId, int geoReferenceId): this()
    {
        Description = description;
        ProjectId = projectId;
        GeoReferenceId = geoReferenceId;
    }

    public int Id { get; }
    public string Description { get; private set; }
    
    public int ProjectId { get; private set; }
    
    public Project Project { get; internal set; }
    
    public int GeoReferenceId { get; private set; }
    
    public GeoReference GeoReference { get; internal set; }
}