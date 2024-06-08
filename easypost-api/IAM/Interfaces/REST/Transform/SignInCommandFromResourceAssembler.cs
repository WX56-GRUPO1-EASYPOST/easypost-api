using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Interfaces.REST.Resources;

namespace easypost_api.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}