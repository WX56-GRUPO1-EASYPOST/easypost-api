namespace easypost_api.Poles.Domain.Model.Commands;

public record CreatePoleCommand(string Description, int ProjectId, int GeoReferenceId);