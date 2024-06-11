using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository, IUnitOfWork unitOfWork): IProjectCommandService
{
    public async Task<Projects?> Handle(CreateProjectCommand command)
    {
        var project = new Projects(
            command.Title,
            command.AccesCode, 
            command.TotalBudget, 
            command.PartialBudget, 
            command.LocationId
            );
        await projectRepository.AddAsync(project);
        await unitOfWork.CompleteAsync();
        return project;
    }

    public async Task<Projects?> Handle(AddConstructionPermitToProjectCommand command)
    {
        var project = await projectRepository.FindByIdAsync(command.ProjectId);
        if (project is null) throw new Exception("Project not found");
        project.AddConstructionPermit(command.Permit);
        await unitOfWork.CompleteAsync();
        return project;
    }
}