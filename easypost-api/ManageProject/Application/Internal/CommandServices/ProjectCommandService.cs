using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository, ILocationRepository locationRepository, IUnitOfWork unitOfWork): IProjectCommandService
{
    public async Task<Project?> Handle(CreateProjectCommand command)
    {
        int accessCode;
        Project? projectAux;
        do
        {
            accessCode = GenerateUniqueAccessCode();
            projectAux = await projectRepository.FindByAccessCodeAsync(accessCode);
        } while (projectAux != null);

        var project = new Project(
            command.Title,
            accessCode,
            command.TotalBudget,
            command.PartialBudget,
            command.LocationId
        );

        await projectRepository.AddAsync(project);
        await unitOfWork.CompleteAsync();
        var location = await locationRepository.FindByIdAsync(command.LocationId);
        project.Location = location;
        return project;
    }

    private static int GenerateUniqueAccessCode()
    {
        return new Random().Next(100000, 999999);
    }

    public async Task<Project?> Handle(AddConstructionPermitToProjectCommand command)
    {
        var project = await projectRepository.FindByIdAsync(command.ProjectId);
        if (project is null) throw new Exception("Project not found");
        project.AddConstructionPermit(command.Permit);
        await unitOfWork.CompleteAsync();
        return project;
    }
}