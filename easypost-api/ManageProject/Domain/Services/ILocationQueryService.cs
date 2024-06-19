using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Queries;

namespace easypost_api.ManageProject.Domain.Services;

public interface ILocationQueryService
{
    Task<Location?> Handle(GetLocationByIdQuery query);
    Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query);
}