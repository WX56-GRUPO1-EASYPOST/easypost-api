namespace easypost_api.Poles.Domain.Model.Commands;

public record AddPolePictureCommand(string PictureUrl, string Description, int PoleId);