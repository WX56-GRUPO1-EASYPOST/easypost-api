using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Poles.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Poles.Application.CommandServices;

public class PoleCommandService(
    IPoleRepository poleRepository,
    IGeoReferenceRepository geoReferenceRepository,
    IUnitOfWork unitOfWork
    ): IPoleCommandService
{
    public async Task<Pole?> Handle(CreatePoleCommand command)
    {
        var pole = new Pole(command.Description, command.ProjectId, command.GeoReferenceId);
        await poleRepository.AddAsync(pole);
        await unitOfWork.CompleteAsync();
        var geoReference = await geoReferenceRepository.FindByIdAsync(command.GeoReferenceId);
        pole.GeoReference = geoReference;
        return pole;
    }

    public async Task<Pole?> Handle(AddPolePictureCommand command)
    {
        var pole = await poleRepository.FindByIdAsync(command.PoleId);
        if (pole is null) throw new Exception("Pole not found");
        pole.AddPolePicture(command.PictureUrl, command.Description);
        return pole;
    }

    public async Task<Pole?> Handle(UpdatePolePictureDescriptionCommand command)
    {
        var pole = await poleRepository.FindByIdAsync(command.PoleId);
        if (pole is null) throw new Exception("Pole not found");
        pole.UpdateImgDescription(command.PolePictureId, command.Description);
        return pole;
    }

    public async Task<Pole?> Handle(DeletePolePictureCommand command)
    {
        var pole = await poleRepository.FindByIdAsync(command.PoleId);
        if (pole is null) throw new Exception("Pole not found");
        pole.RemovePolePicture(command.PictureId);
        return pole;
    }
}