using easypost_api.Poles.Domain.Model.Commands;
using easypost_api.Poles.Domain.Model.Entities;

namespace easypost_api.Poles.Domain.Services;

public interface IGeoReferenceCommandService
{
    public Task<GeoReference?> Handle(CreateGeoReferenceCommand command);
}