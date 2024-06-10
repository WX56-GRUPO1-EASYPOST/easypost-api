using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectCommandService
{
    public Task<Projects?> Handle(CreateProjectCommand command);
    public Task<Projects?> Handle(AddConstructionPermitToProjectCommand command);
}