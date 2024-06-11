using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using easypost_api.ManageProject.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.ManageProject.Interfaces.REST;

[ApiController]
[Route("api/v1/projects")]
public class ProjectController(
    IProjectCommandService projectCommandService,
    IProjectQueryService projectQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectResource createProjectResource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResource(createProjectResource);
        var project = await projectCommandService.Handle(createProjectCommand);
        if (project is null) return BadRequest();
        var resource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return CreatedAtAction(nameof(GetProjectsById), new{projectid = resource.Id}, resource); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var getAllProjectsQuery = new GetAllProjectsQuery();
        var projects = await projectQueryService.Handle(getAllProjectsQuery);
        var resources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectsById([FromRoute] int projectId)
    {
        var project = await projectQueryService.Handle(new GetProjectsByIdQuery(projectId));
        if (project == null) return NotFound();
        var resource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(resource);
    }
    
    [HttpPost("{projectId}/Permits")]
    public async Task<IActionResult> AddPermitToProject([FromBody] AddConstructionPermitToProjectResource addPermitToProjectResource,
        [FromRoute] int projectId)
    {
        var addPermitToProjectCommand =
            AddConstructionPermitToProjectCommandFromResourceAssembler.ToCommandFromResource(addPermitToProjectResource,
                projectId);
        var project = await projectCommandService.Handle(addPermitToProjectCommand);
        var resource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return CreatedAtAction(nameof(GetProjectsById), new { projectId = resource.Id }, resource);
    }
    
}