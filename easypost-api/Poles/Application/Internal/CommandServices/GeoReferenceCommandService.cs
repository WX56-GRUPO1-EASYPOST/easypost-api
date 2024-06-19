using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Domain.Model.Entities;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Poles.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Poles.Application.CommandServices;

public class GeoReferenceCommandService(
    IGeoReferenceRepository geoReferenceRepository,
    IUnitOfWork unitOfWork
    ): IGeoReferenceCommandService
{
    public async Task<GeoReference?> Handle(CreateGeoReferenceCommand command)
    {
        var geoReference = new GeoReference(
            command.Latitude,
            command.Longitude,
            command.Description
        );
        await geoReferenceRepository.AddAsync(geoReference);
        await unitOfWork.CompleteAsync();
        return geoReference;
    }
}