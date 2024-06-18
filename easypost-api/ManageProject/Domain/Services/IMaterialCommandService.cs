using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Domain.Services;

public interface IMaterialCommandService
{
    public Task<Material?> Handle(CreateMaterialCommand command);
}