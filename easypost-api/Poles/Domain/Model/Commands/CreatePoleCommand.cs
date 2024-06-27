namespace easypost_api.Poles.Domain.Model.Commands;

public record CreatePoleCommand(
    string Description, 
    int ProjectId, 
    string Latitude, 
    string Longitude, 
    string GeoDescription
    );