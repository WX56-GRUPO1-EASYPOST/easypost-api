using easypost_api.ManageProject.Application.Internal.CommandServices;
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
    public async Task<IActionResult> GetProjectsById([FromRoute] int projectId)
    {
        var project = await projectQueryService.Handle(new GetProjectsByIdQuery(projectId));
        if (project == null) return NotFound();
        var resource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(resource);
    }
}