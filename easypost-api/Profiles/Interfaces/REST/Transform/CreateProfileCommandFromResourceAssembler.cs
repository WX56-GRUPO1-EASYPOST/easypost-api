using easypost_api.Profiles.Domain.Model.Commands;
using easypost_api.Profiles.Interfaces.REST.resources;

namespace easypost_api.Profiles.Interfaces.REST.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
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