using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class CreatePoleCommandFromResourceAssembler
{
    public static CreatePoleCommand ToCommandFromResource(CreatePoleResource resource)
    {
        return new CreatePoleCommand(
            resource.Description,
            resource.ProjectId,
            resource.Latitude,
            resource.Longitude,
            resource.GeoDescription
            );
    }
}