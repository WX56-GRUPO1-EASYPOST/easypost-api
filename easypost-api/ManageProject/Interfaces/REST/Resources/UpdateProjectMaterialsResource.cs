namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record UpdateProjectMaterialsResource(int ProjectId, int MaterialId, int Amount);