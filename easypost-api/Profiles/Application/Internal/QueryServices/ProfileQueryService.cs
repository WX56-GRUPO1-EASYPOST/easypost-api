using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Profiles.Domain.Services;

namespace easypost_api.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService : IProfileQueryService
{
    private readonly IProfileRepository _profileRepository;
    public ProfileQueryService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await _profileRepository.FindByIdAsync(query.ProfileId);
      
    }

    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await _profileRepository.ListAsync();
    }

    public bool Handle(ExistProfileByIdQuery query)
    {
        return _profileRepository.ExistsById(query.ProfileId);
    }
}