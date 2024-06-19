namespace easypost_api.Poles.Domain.Model.Commands;

public record UpdatePolePictureDescriptionCommand(int PoleId, int PolePictureId, string Description);