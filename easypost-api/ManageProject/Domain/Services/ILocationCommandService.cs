using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Domain.Services;

public interface ILocationCommandService
{
    public Task<Location?> Handle(CreateLocationCommand command);
}