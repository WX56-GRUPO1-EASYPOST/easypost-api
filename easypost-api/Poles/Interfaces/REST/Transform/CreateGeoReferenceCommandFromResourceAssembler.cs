using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class CreateGeoReferenceCommandFromResourceAssembler
{
    public static CreateGeoReferenceCommand ToCommandFromResource(CreateGeoReferenceResource resource)
    {
        return new CreateGeoReferenceCommand(
            resource.Latitude, 
            resource.Longitude, 
            resource.Description
            );
    }
}