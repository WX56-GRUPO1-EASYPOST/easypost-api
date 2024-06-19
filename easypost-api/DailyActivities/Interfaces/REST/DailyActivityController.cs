using easypost_api.DailyActivities.Domain.Model.Queries;
using easypost_api.DailyActivities.Domain.Services;
using easypost_api.DailyActivities.Interfaces.REST.Resources;
using easypost_api.DailyActivities.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.DailyActivities.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class DailyActivityController(
    IDailyActivityCommandService dailyActivityCommandService,
    IDailyActivityQueryService dailyActivityQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDailyActivity([FromBody] CreateDailyActivityResource resource)
    {
        var createDailyActivityCommand = CreateDailyActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
        var dailyActivity = await dailyActivityCommandService.Handle(createDailyActivityCommand);
        if(dailyActivity is null) return BadRequest();
        var response = DailyActivityResourceFromEntityAssembler.ToResourceFromEntity(dailyActivity);
        return CreatedAtAction(nameof(GetDailyActivityById), new { dailyActivityId = response.Id }, response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDailyActivities()
    {
        var query = new GetAllDailyActivitiesQuery();
        var dailyActivities = await dailyActivityQueryService.Handle(query);
        var resources = dailyActivities.Select(DailyActivityResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{dailyActivityId}")]
    public async Task<IActionResult> GetDailyActivityById([FromRoute] int dailyActivityId)
    {
        var dailyActivity = await dailyActivityQueryService.Handle(new GetDailyActivityByIdQuery(dailyActivityId));
        if(dailyActivity == null) return NotFound();
        var resource = DailyActivityResourceFromEntityAssembler.ToResourceFromEntity(dailyActivity);
        return Ok(resource);
    }
    
    [HttpPost("{dailyActivityId}/pictures")]
    public async Task<IActionResult> AddPictureToDailyActivity([FromBody] AddDailyActivityPictureResource resource,
        [FromRoute] int dailyActivityId)
    {
        var command = AddDailyActivityPictureCommandFromResourceAssembler.ToCommandFromResource(resource, dailyActivityId);
        var dailyActivity = await dailyActivityCommandService.Handle(command);
        var response = DailyActivityResourceFromEntityAssembler.ToResourceFromEntity(dailyActivity);
        return CreatedAtAction(nameof(GetDailyActivityById), new { dailyActivityId = response.Id }, response);
    }
    
    [HttpDelete("{dailyActivityId}/pictures")]
    public async Task<IActionResult> DeletePictureFromDailyActivity([FromBody] DeleteDailyActivityPictureResource resource,
        [FromRoute] int dailyActivityId)
    {
        var command = DeleteDailyActivityPictureCommandFromResourceAssembler.ToCommandFromResource(resource, dailyActivityId);
        var dailyActivity = await dailyActivityCommandService.Handle(command);
        var response = DailyActivityResourceFromEntityAssembler.ToResourceFromEntity(dailyActivity);
        return CreatedAtAction(nameof(GetDailyActivityById), new { dailyActivityId = response.Id }, response);
    }
    
    [HttpPut("{dailyActivityId}/pictures")]
    public async Task<IActionResult> UpdatePictureDescription([FromBody] UpdateDailyActivityPictureDescriptionResource resource,
        [FromRoute] int dailyActivityId)
    {
        var command = UpdateDailyActivityPictureDescriptionCommandFromResourceAssembler.ToCommandFromResource(resource, dailyActivityId);
        var dailyActivity = await dailyActivityCommandService.Handle(command);
        var response = DailyActivityResourceFromEntityAssembler.ToResourceFromEntity(dailyActivity);
        return CreatedAtAction(nameof(GetDailyActivityById), new { dailyActivityId = response.Id }, response);
    }
}