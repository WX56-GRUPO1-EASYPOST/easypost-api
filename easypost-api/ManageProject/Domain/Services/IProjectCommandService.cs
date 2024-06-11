using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Commands;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectCommandService
{
    Task<Projects?> Handle(CreateProjectCommand command);
    Task<Projects?> Handle(AddConstructionPermitToProjectCommand command);
}