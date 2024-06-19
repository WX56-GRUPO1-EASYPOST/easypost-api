using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Queries;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using easypost_api.ManageProject.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.ManageProject.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class MaterialController(
    IMaterialCommandService materialCommandService,
    IMaterialQueryService materialQueryService
): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMaterial([FromBody] CreateMaterialResource createMaterialResource)
    {
        var createMaterialCommand = CreateMaterialCommandFromResourceAssembler.ToCommandFromResource(createMaterialResource);
        var material = await materialCommandService.Handle(createMaterialCommand);
        if (material is null) return BadRequest();
        var resource = MaterialResourceFromEntityAssembler.ToResourceFromEntity(material);
        return CreatedAtAction(nameof(GetMaterialById), new { materialId = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllMaterials()
    {
        var getAllMaterialsQuery = new GetAllMaterialsQuery();
        var materials = await materialQueryService.Handle(getAllMaterialsQuery);
        var resources = materials.Select(MaterialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{materialId}")]
    public async Task<IActionResult> GetMaterialById([FromRoute] int materialId)
    {
        var material = await materialQueryService.Handle(new GetMaterialByIdQuery(materialId));
        if (material == null) return NotFound();
        var resource = MaterialResourceFromEntityAssembler.ToResourceFromEntity(material);
        return Ok(resource);
    }
}