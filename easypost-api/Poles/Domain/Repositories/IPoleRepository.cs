using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Poles.Domain.Repositories;

public interface IPoleRepository: IBaseRepository<Pole>
{
    Task<IEnumerable<Pole>> FindByGeoReferenceIdAsync(int geoReferenceId);
    Task<IEnumerable<Pole>> FindByProjectIdAsync(int projectId);
}