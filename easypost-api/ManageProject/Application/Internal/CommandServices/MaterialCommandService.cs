using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Application.Internal.CommandServices;

public class MaterialCommandService(
    IMaterialRepository materialRepository,
    IUnitOfWork unitOfWork
    ): IMaterialCommandService
{
    public async Task<Material?> Handle(CreateMaterialCommand command)
    {
        if (command.Cost < 0)
        {
            throw new ArgumentException("Cost cannot be negative");
        }
        if (command.Cost == 0)
        {
            throw new ArgumentException("Cost cannot be zero");
        }
        var material = new Material(
            command.Name,
            command.Description,
            command.Cost
            );
        var materialExists = await materialRepository.FindByNameAsync(material.Name);
        if (materialExists != null)
        {
            throw new ArgumentException("Material already exists");
        }
        await materialRepository.AddAsync(material);
        await unitOfWork.CompleteAsync();
        return material;
    }
}