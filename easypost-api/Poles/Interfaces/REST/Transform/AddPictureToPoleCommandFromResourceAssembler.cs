using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Interfaces.REST.Resources;

namespace easypost_api.Poles.Interfaces.REST.Transform;

public static class AddPictureToPoleCommandFromResourceAssembler
{
    public static AddPolePictureCommand ToCommandFromResource(AddPictureToPoleResource resource, int poleId)
    {
        return new AddPolePictureCommand(resource.PictureUrl, resource.Description, poleId);
    }
}