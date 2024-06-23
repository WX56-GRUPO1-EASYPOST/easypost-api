using easypost_api.IAM.Interfaces.ACL;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Profiles.Domain.Services;

namespace easypost_api.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService : IProfileQueryService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUserContextFacade _userContextFacade;
    public ProfileQueryService(IProfileRepository profileRepository,
        IUserContextFacade userContextFacade)
    {
        _profileRepository = profileRepository;
        _userContextFacade = userContextFacade;
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

    public async Task<Profile?> Handle(GetProfileByUserIdQuery query)
    {
        var exists = await _userContextFacade.ExistsUserId(query.UserId); 
        if (!exists)
        {
            return null;
        }

        var profile = await _profileRepository.FindByUserIdAsync(query.UserId);
        if (profile==null)
        {
            return null;
        }

        return profile;
    }

    public async Task<IEnumerable<Profile>> Handle(GetAllEnterpriseProfilesQuery query)
    {
        var profiles = await this.Handle(new GetAllProfilesQuery());
        if (!profiles.Any())
        {
            return Enumerable.Empty<Profile>();
        }
        var enterpriseProfiles = profiles
            .Where(profile =>_userContextFacade.IsEnterprise(profile.UserId).Result == true);
        return enterpriseProfiles;
    }
}