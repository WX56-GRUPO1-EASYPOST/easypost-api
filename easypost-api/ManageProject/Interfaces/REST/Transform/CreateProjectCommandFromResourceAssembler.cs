using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Interfaces.REST.Resources;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public static class CreateProjectCommandFromResourceAssembler {
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource createProjectCommand) {
        return new CreateProjectCommand (
            createProjectCommand.Title,
            createProjectCommand.TotalBudget,
            createProjectCommand.PartialBudget,
            createProjectCommand.LocationId,
            createProjectCommand.CompanyProfileId
        );
    }
}