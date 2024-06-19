namespace easypost_api.ManageProject.Domain.Model.Commands;

public record UpdateAmountMaterialCommand(int ProjectId, int MaterialId, int Amount);