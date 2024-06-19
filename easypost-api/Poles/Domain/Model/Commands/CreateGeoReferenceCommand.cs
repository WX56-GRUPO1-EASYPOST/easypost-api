namespace easypost_api.Poles.Domain.Model.Commands;

public record CreateGeoReferenceCommand(string Latitude, string Longitude, string Description);