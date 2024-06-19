using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class UpdatePolePictureDescriptionCommandFromResourceAssembler
{
    public static UpdatePolePictureDescriptionCommand ToCommandFromResource(
        UpdatePolePictureDescriptionResource resource, int poleId
        )
    {
        return new UpdatePolePictureDescriptionCommand(poleId, resource.PictureId, resource.Description);
    }
}