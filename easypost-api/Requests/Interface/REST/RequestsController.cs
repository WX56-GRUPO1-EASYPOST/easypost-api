using System.Net.Mime;
using easypost_api.Requests.Domain.Model.Queries;
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
}
