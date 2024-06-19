namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record CreateProjectMaterialsResource(int ProjectId, int MaterialId, int Amount);