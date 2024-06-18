using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectMaterialsCommandService
{
    public Task<ProjectMaterials> Handle(CreateProjectMaterialCommand command);
    public Task<ProjectMaterials> Handle(UpdateAmountMaterialCommand command);
}