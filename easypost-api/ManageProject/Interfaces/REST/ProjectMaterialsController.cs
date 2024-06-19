using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using easypost_api.ManageProject.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.ManageProject.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProjectMaterialsController(
    IProjectMaterialsCommandService projectMaterialsCommand,
    IProjectMaterialsQueryService projectMaterialsQuery
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProjectMaterial([FromBody] CreateProjectMaterialsResource resource)
    {
        var command = CreateProjectMaterialsCommandFromResourceAssembler.ToCommandFromResource(resource);
        var projectMaterial = await projectMaterialsCommand.Handle(command);
        if (projectMaterial is null) return BadRequest();
        var response = ProjectMaterialsResourceFromEntityAssembler.ToResourceFromEntity(projectMaterial);
        return CreatedAtAction(nameof(GetProjectMaterialByProjectIdAndMaterialId), new { projectId = response.ProjectId, materialId = response.MaterialId }, response);
    }

    [HttpGet("{projectId:int}/{materialId:int}")]
    public async Task<IActionResult> GetProjectMaterialByProjectIdAndMaterialId(int projectId, int materialId)
    {
        var query = new GetProjectMaterialByProjectIdAndMaterialIdQuery(projectId, materialId);
        var projectMaterial = await projectMaterialsQuery.Handle(query);
        if (projectMaterial is null) return NotFound();
        var response = ProjectMaterialsResourceFromEntityAssembler.ToResourceFromEntity(projectMaterial);
        return Ok(response);
    }

    [HttpGet("{projectId:int}")]
    public async Task<IActionResult> GetProjectMaterialsByProjectId(int projectId)
    {
        var query = new GetProjectMaterialByProjectIdQuery(projectId);
        var projectMaterials = await projectMaterialsQuery.Handle(query);
        if (projectMaterials is null || !projectMaterials.Any()) return NotFound();
        var response = projectMaterials.Select(ProjectMaterialsResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(response);
    }
}