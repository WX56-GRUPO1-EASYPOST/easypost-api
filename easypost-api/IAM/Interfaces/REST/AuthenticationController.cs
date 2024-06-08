using System.Net.Mime;
using easypost_api.IAM.Domain.Services;
using easypost_api.IAM.Interfaces.REST.Resources;
using easypost_api.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace easypost_api.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(
    IUserCommandService userCommandService):ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var resource = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser);
        return Ok(resource);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new {message="User created successfully"});
    }
    
}