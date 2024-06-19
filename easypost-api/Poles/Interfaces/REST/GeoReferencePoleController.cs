using easypost_api.Poles.Domain.Model.Queries;
using easypost_api.Poles.Domain.Services;
using easypost_api.Poles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Poles.Interfaces.REST;

[ApiController]
[Route("api/v1/geoReferences/{geoReferenceId}/Poles")]
[Tags("GeoReferences")]
public class GeoReferencePoleController(
    IPoleQueryService poleQueryService
    ): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPolesByGeoReferenceId([FromRoute] int geoReferenceId)
    {
        var getPolesByGeoReferenceIdQuery = new GetPolesByGeoReferenceIdQuery(geoReferenceId);
        var poles = await poleQueryService.Handle(getPolesByGeoReferenceIdQuery);
        var resources = poles.Select(PoleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}