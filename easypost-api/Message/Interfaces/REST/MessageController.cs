using System.Net.Mime;
using easypost_api.Message.Domain.Model.Queries;
using easypost_api.Message.Domain.Services;
using easypost_api.Message.Interfaces.REST.Resources;
using easypost_api.Message.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.Message.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MessageController(IMessageCommandService messageCommandService, IMessageQueryService messageQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMessage([FromBody] CreateMessageResource resource)
    {
        var createMessageCommand = CreateMessageCommandFromResourceAssembler.ToCommandFromResource(resource);
        var message = await messageCommandService.Handle(createMessageCommand);
        if (message == null)
        {
            return BadRequest();
        }

        var messageResource = MessageResourceFromEntityAssembler.ToResourceFromEntity(message);
        return Created("", messageResource);
    }

    [HttpGet("{messageId:int}")]
    public async Task<IActionResult> GetMessageById(int messageId)
    {
        var getMessageByIdQuery = new GetMessageByIdQuery(messageId);
        var message = await messageQueryService.Handle(getMessageByIdQuery);
        if (message==null)
        {
            return NotFound();
        }

        var messageResource = MessageResourceFromEntityAssembler.ToResourceFromEntity(message);
        return Ok(messageResource);

    }

    [HttpGet("recipient/{recipientId:int}")]
    public async Task<IActionResult> GetAllMessagesByRecipientAndSenderId(int recipientId,[FromQuery] int senderId)
    {
        var query = new GetAllMessagesByRecipientAndSenderIdQuery(recipientId,senderId);
        var messages = await messageQueryService.Handle(query);
        var resources = messages.Select(MessageResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}