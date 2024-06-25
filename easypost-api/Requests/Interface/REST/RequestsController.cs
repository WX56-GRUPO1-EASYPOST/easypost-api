using System.Net.Mime;
using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Model.Queries;
using easypost_api.Requests.Domain.Model.ValueObjects;
using easypost_api.Requests.Domain.Services;
using easypost_api.Requests.Interface.REST.Resources;
using easypost_api.Requests.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Requests.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RequestsController(IRequestCommandService requestCommandService, IRequestQueryService requestQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRequest(CreateRequestByFormResource resource)
    {
        var createRequestByFormCommand =
            CreateRequestByFormCommandFromResourceAssembler.ToCommandFromResource(resource);
        var request = await requestCommandService.Handle(createRequestByFormCommand);
        if (request is null) return BadRequest();
        var requestResource = RequestResourceFromEntityAssembler.ToResourceFromEntity(request);
        return CreatedAtAction(nameof(GetRequestById), new { requestId = request.Id }, requestResource);
    }

    [HttpGet("{requestId:int}")]
    public async Task<IActionResult> GetRequestById(int requestId)
    {
        var getRequestByIdQuery = new GetRequestByIdQuery(requestId);
        var request = await requestQueryService.Handle(getRequestByIdQuery);
        if (request == null) return NotFound();
        var requestResource = RequestResourceFromEntityAssembler.ToResourceFromEntity(request);
        return Ok(requestResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRequests()
    {
        var getAllRequestsQuery = new GetAllRequestsQuery();
        var requests = await requestQueryService.Handle(getAllRequestsQuery);
        var resources = requests.Select(RequestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("enterprise/{enterpriseId:int}/filter")]
    public async Task<IActionResult> GetAllRequestsByEnterpriseIdAndStatus(int enterpriseId,
        [FromQuery] ERequestStatus status)
    {
        var query = new GetAllRequestsByEnterpriseIdAndStatusQuery(enterpriseId, status);
        var requests = await requestQueryService.Handle(query);
        var resources = requests.Select(RequestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("client/{clientId:int}/filter")]
    public async Task<IActionResult> GetAllRequestsByClientIdAndStatus(int clientId,
        [FromQuery] ERequestStatus status)
    {
        var query = new GetAllRequestsByClientIdAndStatusQuery(clientId, status);
        var requests = await requestQueryService.Handle(query);
        var resources = requests.Select(RequestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPatch("{requestId:int}/update-status")]
    public async Task<IActionResult> UpdateRequestStatus(int requestId,[FromQuery] ERequestStatus status)
    {
        var query = new UpdateRequestStatusCommand(requestId, status);
        var request = await requestCommandService.Handle(query);
        if (request is null) return BadRequest();
        var resource = RequestResourceFromEntityAssembler.ToResourceFromEntity(request);
        return Ok(resource);
    }
}
