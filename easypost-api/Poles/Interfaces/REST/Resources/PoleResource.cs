namespace easypost_api.Poles.Interfaces.REST.Resources;

public record PoleResource(int Id, string Description, int ProjectId, int GeoReferenceId, GeoReferenceResource GeoReference);