using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Queries;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectQueryService
{
    Task<Project?> Handle(GetProjectsByIdQuery query);
    Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query);
    Task<IEnumerable<Project>> Handle(GetProjectsByLocationQuery query);
}