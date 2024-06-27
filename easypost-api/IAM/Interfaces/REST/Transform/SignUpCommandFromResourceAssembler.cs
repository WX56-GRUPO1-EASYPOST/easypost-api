using easypost_api.IAM.Domain.Model.Commands;
using easypost_api.IAM.Interfaces.REST.Resources;

namespace easypost_api.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(
            resource.Username, 
            resource.Password,
            resource.Type,
            resource.Name,
            resource.Description,
            resource.Ruc,
            resource.Phone,
            resource.Email,
            resource.Department,
            resource.District,
            resource.Residential
            );
    }
}