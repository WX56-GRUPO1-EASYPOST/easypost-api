using System.Net.Mime;
using easypost_api.Profiles.Interfaces.ACL;
using easypost_api.Tickets.Domain.Model.Queries;
using easypost_api.Tickets.Domain.Services;
using easypost_api.Tickets.Interfaces.REST.Resources;
using easypost_api.Tickets.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Tickets.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TicketsController(ITicketCommandService ticketCommandService,
    ITicketQueryService ticketQueryService, IProfilesContextFacade profilesContextFacade) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketResource resource)
    {
        if (!profilesContextFacade.ExistsProfileById(resource.ProfileId)) return BadRequest();
        var createTicketCommand = CreateTicketCommandFromResourceAssembler.ToCommandFromResource(resource);
        var ticket = await ticketCommandService.Handle(createTicketCommand);
        if (ticket == null) return  BadRequest();
        var ticketResource = TicketResourceFromEntityAssembler.ToResourceFromEntity(ticket);
        return CreatedAtAction(nameof(GetTicketById), new { ticketId = ticket.Id }, ticketResource);
    }

    [HttpGet("{ticketId:int}")]
    public async Task<IActionResult> GetTicketById(int ticketId)
    {
        var getTicketByIdQuery = new GetTicketByIdQuery(ticketId);
        var ticket = await ticketQueryService.Handle(getTicketByIdQuery);
        if (ticket == null) return NotFound();
        var ticketResource = TicketResourceFromEntityAssembler.ToResourceFromEntity(ticket);
        return Ok(ticketResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var getAllTickets = new GetAllTicketsQuery();
        var tickets = await ticketQueryService.Handle(getAllTickets);
        var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllTicketsByStatus([FromQuery] int status)
    {
        var getTicketsByStatusQuery = new GetAllTicketsByStatus(status);
        var tickets = await ticketQueryService.Handle(getTicketsByStatusQuery);
        var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}