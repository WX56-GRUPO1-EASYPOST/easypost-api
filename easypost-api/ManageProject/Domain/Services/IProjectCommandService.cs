using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectCommandService
{
    Task<Project?> Handle(CreateProjectCommand command);
    Task<Project?> Handle(AddConstructionPermitToProjectCommand command);
}