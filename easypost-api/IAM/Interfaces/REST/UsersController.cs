using System.Net.Mime;
using easypost_api.IAM.Domain.Model.Queries;
using easypost_api.IAM.Domain.Services;
using easypost_api.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService):ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}