using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;

namespace easypost_api.ManageProject.Application.Internal.QueryServices;

public class ProjectQueryService(IProjectRepository projectRepository): IProjectQueryService
{
    public async Task<Project?> Handle(GetProjectsByIdQuery query)
    {
        return await projectRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query)
    {
        return await projectRepository.ListAsync();
    }

    public Task<IEnumerable<Project>> Handle(GetProjectsByLocationQuery query)
    {
        return projectRepository.FindByLocationIdAsync(query.LocationId);
    }
    
    public Task<Project?> Handle(GetProjectsByAccessCodeQuery query)
    {
        return projectRepository.FindByAccessCodeAsync(query.AccessCode);
    }
}