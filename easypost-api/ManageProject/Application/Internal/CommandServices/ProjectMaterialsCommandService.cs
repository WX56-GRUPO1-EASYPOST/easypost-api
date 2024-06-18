using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Application.Internal.CommandServices;

public class ProjectMaterialsCommandService(
        IProjectMaterialRepository projectMaterialRepository,
        IUnitOfWork unitOfWork
    ): IProjectMaterialsCommandService
{
    public async Task<ProjectMaterials> Handle(CreateProjectMaterialCommand command)
    {
        var projectMaterial = new ProjectMaterials(
            command.ProjectId,
            command.MaterialId,
            command.Amount
        );
        await projectMaterialRepository.AddAsync(projectMaterial);
        await unitOfWork.CompleteAsync();
        return projectMaterial;
    }

    public async Task<ProjectMaterials> Handle(UpdateAmountMaterialCommand command)
    {
        var projectMaterial = await projectMaterialRepository.FindByProjectIdAndMaterialIdAsync(command.ProjectId, command.MaterialId);
        if (projectMaterial == null)
        {
            throw new Exception("Project material not found");
        }
        projectMaterial.UpdateAmount(command.Amount);
        await unitOfWork.CompleteAsync();
        return projectMaterial;
    }
}