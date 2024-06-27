namespace easypost_api.Poles.Interfaces.REST.Resources;

public record CreatePoleResource(
    string Description,
    int ProjectId, 
    string Latitude, 
    string Longitude, 
    string GeoDescription
    );