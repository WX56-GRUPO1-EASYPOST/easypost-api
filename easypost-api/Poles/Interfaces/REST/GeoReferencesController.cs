using easypost_api.Poles.Domain.Model.Queries;
using easypost_api.Poles.Domain.Services;
using easypost_api.Poles.Interfaces.REST.Resources;
using easypost_api.Poles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Poles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class GeoReferencesController(
    IGeoReferenceCommandService geoReferenceCommandService,
    IGeoReferenceQueryService geoReferenceQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGeoReference([FromBody] CreateGeoReferenceResource createGeoReferenceResource)
    {
        var createGeoReference = 
            CreateGeoReferenceCommandFromResourceAssembler.ToCommandFromResource(createGeoReferenceResource);
        var geoReference = await geoReferenceCommandService
            .Handle(createGeoReference);
        if(geoReference is null) return BadRequest();
        var resource = GeoReferenceResourceFromEntityAssembler.ToResourceFromEntity(geoReference);
        return CreatedAtAction(nameof(GetGeoReferenceById), new { geoReferenceId = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllGeoReferences()
    {
        var getAllGeoReferencesQuery = new GetAllGeoReferencesQuery();
        var geoReferences = await geoReferenceQueryService.Handle(getAllGeoReferencesQuery);
        var resources = geoReferences.Select(GeoReferenceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{geoReferenceId}")]
    public async Task<IActionResult> GetGeoReferenceById([FromRoute] int geoReferenceId)
    {
        var geoReference = await geoReferenceQueryService.Handle(new GetGeoReferenceByIdQuery(geoReferenceId));
        if(geoReference == null) return NotFound();
        var resource = GeoReferenceResourceFromEntityAssembler.ToResourceFromEntity(geoReference);
        return Ok(resource);
    }
}