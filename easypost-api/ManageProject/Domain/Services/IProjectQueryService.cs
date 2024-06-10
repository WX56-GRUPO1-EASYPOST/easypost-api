using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Queries;

namespace easypost_api.ManageProject.Domain.Services;

public interface IProjectQueryService
{
    Task<Projects?> Handle(GetProjectsByIdQuery query);
    Task<IEnumerable<Projects>> Handle(GetAllProjectsQuery query);
    Task<IEnumerable<Projects>> Handle(GetProjectsByLocationQuery query);
}