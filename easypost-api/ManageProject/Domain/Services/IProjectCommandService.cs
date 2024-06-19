using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectCommandService
{
    public Task<Project?> Handle(CreateProjectCommand command);
    public Task<Project?> Handle(AddConstructionPermitToProjectCommand command);
}