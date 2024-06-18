namespace easypost_api.ManageProject.Domain.Model.Commands;

public record CreateProjectMaterialCommand(int ProjectId, int MaterialId, int Amount);