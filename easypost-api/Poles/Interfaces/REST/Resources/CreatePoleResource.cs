namespace easypost_api.Poles.Interfaces.REST.Resources;

public record CreatePoleResource(string Description, int ProjectId, int GeoReferenceId);