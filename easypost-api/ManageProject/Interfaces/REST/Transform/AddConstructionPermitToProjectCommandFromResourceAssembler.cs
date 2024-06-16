using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public static class AddConstructionPermitToProjectCommandFromResourceAssembler
{
    public static AddConstructionPermitToProjectCommand ToCommandFromResource(
        AddConstructionPermitToProjectResource resource, int projectId)
    {
        return new AddConstructionPermitToProjectCommand(projectId, resource.Permit);
    }
}