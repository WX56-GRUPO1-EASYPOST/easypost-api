using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.ManageProject.Interfaces.REST;

[ApiController]
[Route("api/v1/locations/{locationId:int}/projects")]
[Tags("Location")]
public class LocationProjectController(
        IProjectQueryService projectQueryService
    ): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProjectsByLocationId([FromRoute] int locationId)
    {
        var getProjectsByLocationIdQuery = new GetProjectsByLocationQuery(locationId);
        var projects = await projectQueryService.Handle(getProjectsByLocationIdQuery);
        var resources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}