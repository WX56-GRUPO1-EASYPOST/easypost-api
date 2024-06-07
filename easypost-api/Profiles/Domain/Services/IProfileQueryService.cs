using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Queries;

namespace easypost_api.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile?> Handle(GetProfileByIdQuery query);
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
}