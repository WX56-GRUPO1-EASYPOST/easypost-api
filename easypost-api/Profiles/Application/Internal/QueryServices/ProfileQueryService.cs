using easypost_api.IAM.Interfaces.ACL;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Profiles.Domain.Services;

namespace easypost_api.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(
    IProfileRepository profileRepository
    ) : IProfileQueryService
{
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
      
    }

    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public bool Handle(ExistProfileByIdQuery query)
    {
        return profileRepository.ExistsById(query.ProfileId);
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
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