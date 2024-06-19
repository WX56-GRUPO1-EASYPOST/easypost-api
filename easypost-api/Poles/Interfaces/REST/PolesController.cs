using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Domain.Model.Queries;
using easypost_api.Poles.Domain.Services;
using easypost_api.Poles.Interfaces.REST.Resources;
using easypost_api.Poles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Poles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PolesController(
    IPoleCommandService poleCommandService,
    IPoleQueryService poleQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePole([FromBody] CreatePoleResource createPoleResource)
    {
        var createPoleCommand = 
            CreatePoleCommandFromResourceAssembler.ToCommandFromResource(createPoleResource);
        var pole = await poleCommandService.
            Handle(createPoleCommand);
        if(pole is null) return BadRequest();
        var resource = PoleResourceFromEntityAssembler.ToResourceFromEntity(pole);
        return CreatedAtAction(nameof(GetPoleById), new { poleId = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPoles()
    {
        var getAllPolesQuery = new GetAllPolesQuery();
        var poles = await poleQueryService.Handle(getAllPolesQuery);
        var resources = poles.Select(PoleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{poleId}")]
    public async Task<IActionResult> GetPoleById([FromRoute] int poleId)
    {
        var pole = await poleQueryService.Handle(new GetPoleByIdQuery(poleId));
        if(pole == null) return NotFound();
        var resource = PoleResourceFromEntityAssembler.ToResourceFromEntity(pole);
        return Ok(resource);
    }
    
    [HttpPost("{poleId}/pictures")]
    public async Task<IActionResult> AddPictureToPole([FromBody] AddPictureToPoleResource addPictureToPoleResource,
        [FromRoute] int poleId)
    {
        var addPictureToPoleCommand = 
            AddPictureToPoleCommandFromResourceAssembler.ToCommandFromResource(addPictureToPoleResource, 
                poleId);
        var pole = await poleCommandService.Handle(addPictureToPoleCommand);
        var resource = PoleResourceFromEntityAssembler.ToResourceFromEntity(pole);
        return CreatedAtAction(nameof(GetPoleById), new { poleId = resource.Id }, resource);
    }
    
    [HttpPut("{poleId}/pictures")]
    public async Task<IActionResult> UpdatePictureDescription([FromBody] UpdatePolePictureDescriptionResource updatePolePictureDescriptionResource,
        [FromRoute] int poleId)
    {
        var updatePolePictureDescriptionCommand = 
            UpdatePolePictureDescriptionCommandFromResourceAssembler.ToCommandFromResource(updatePolePictureDescriptionResource, 
                poleId);
        var pole = await poleCommandService.Handle(updatePolePictureDescriptionCommand);
        var resource = PoleResourceFromEntityAssembler.ToResourceFromEntity(pole);
        return CreatedAtAction(nameof(GetPoleById), new { poleId = resource.Id }, resource);
    }
    
    [HttpDelete("{poleId}/pictures/{pictureId}")]
    public async Task<IActionResult> DeletePicture([FromRoute] int poleId, [FromRoute] int pictureId)
    {
        var deletePictureCommand = new DeletePolePictureCommand(poleId, pictureId);
        var pole = await poleCommandService.Handle(deletePictureCommand);
        var resource = PoleResourceFromEntityAssembler.ToResourceFromEntity(pole);
        return CreatedAtAction(nameof(GetPoleById), new { poleId = resource.Id }, resource);
    }
}