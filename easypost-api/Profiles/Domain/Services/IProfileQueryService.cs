using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.domain.model.queries;

namespace easypost_api.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile?> Handle(GetProfileByIdQuery query);
}