using System.Net.Mime;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Services;
using easypost_api.Profiles.Interfaces.REST.resources;
using easypost_api.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById),new {profileID = profile.Id},profileResource);
    }

    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
}