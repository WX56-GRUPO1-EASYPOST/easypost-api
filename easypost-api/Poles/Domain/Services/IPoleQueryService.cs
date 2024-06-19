using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Queries;

namespace easypost_api.Poles.Domain.Services;

public interface IPoleQueryService
{
    Task<IEnumerable<Pole?>> Handle(GetAllPolesQuery query);
    Task<Pole?> Handle(GetPoleByIdQuery query);
    Task<IEnumerable<Pole?>> Handle(GetPolesByGeoReferenceIdQuery query);
    Task<IEnumerable<Pole?>> Handle(GetPolesByProjectIdQuery query);
}