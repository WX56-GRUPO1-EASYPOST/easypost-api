using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using easypost_api.ManageProject.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.ManageProject.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class LocationController(
        ILocationCommandService locationCommandService,
        ILocationQueryService locationQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationResource createLocationResource)
    {
        var createLocationCommand = CreateLocationCommandFromResourceAssembler.ToCommandFromResource(createLocationResource);
        var location = await locationCommandService.Handle(createLocationCommand);
        if (location is null) return BadRequest();
        var resource = LocationResourceFromEntityAssembler.ToResourceFromEntity(location);
        return CreatedAtAction(nameof(GetLocationById), new { locationId = resource.Id }, resource);
    }
    
    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetLocationById([FromRoute] int locationId)
    {
        var location = await locationQueryService.Handle(new GetLocationByIdQuery(locationId));
        if (location == null) return NotFound();
        var resource = LocationResourceFromEntityAssembler.ToResourceFromEntity(location);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        var getAllLocationsQuery = new GetAllLocationsQuery();
        var locations = await locationQueryService.Handle(getAllLocationsQuery);
        var resources = locations.Select(LocationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}