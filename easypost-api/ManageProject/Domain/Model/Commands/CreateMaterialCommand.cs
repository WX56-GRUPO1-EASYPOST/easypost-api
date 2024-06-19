namespace easypost_api.ManageProject.Domain.Model.Commands;

public record CreateMaterialCommand(string Name, string Description, int Cost);