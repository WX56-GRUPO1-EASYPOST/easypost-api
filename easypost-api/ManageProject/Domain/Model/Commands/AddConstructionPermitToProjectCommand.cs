namespace easypost_api.ManageProject.Domain.Model.Commands;

public record AddConstructionPermitToProjectCommand(int ProjectId, string Permit);