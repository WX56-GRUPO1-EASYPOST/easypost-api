using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class DeletePolePictureCommandFromResourceAssembler
{
    public static DeletePolePictureCommand ToCommandFromResource(DeletePolePictureResource resource, int PoleId)
    {
        return new DeletePolePictureCommand(PoleId, resource.PictureId);
    }
}