using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Queries;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Poles.Domain.Services;

namespace easypost_api.Poles.Application.Internal.QueryServices;

public class PoleQueryService(IPoleRepository poleRepository): IPoleQueryService
{
    public async Task<IEnumerable<Pole?>> Handle(GetAllPolesQuery query)
    {
        return await poleRepository.ListAsync();
    }

    public async Task<Pole?> Handle(GetPoleByIdQuery query)
    {
        return await poleRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Pole?>> Handle(GetPolesByGeoReferenceIdQuery query)
    {
        return await poleRepository.FindByGeoReferenceIdAsync(query.GeoReferenceId);
    }

    public async Task<IEnumerable<Pole?>> Handle(GetPolesByProjectIdQuery query)
    {
        return await poleRepository.FindByProjectIdAsync(query.ProjectId);
    }
}