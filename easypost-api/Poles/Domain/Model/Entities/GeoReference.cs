using easypost_api.Poles.Domain.Model.Aggregates;

namespace easypost_api.Poles.Domain.Model.Entities;


public class GeoReference
{
    public GeoReference(string latitude, string longitude, string description)
    {
        Latitude = latitude;
        Longitude = longitude;
        Description = description;
    }

    public int Id { get; }
    
    public string Latitude { get; private set; }
    
    public string Longitude { get; private set; }
 
    public string Description { get; private set; }
    
    public Pole Poles { get; }

}