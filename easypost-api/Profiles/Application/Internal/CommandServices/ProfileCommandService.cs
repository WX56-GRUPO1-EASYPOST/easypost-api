using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.domain.model.commands;
using easypost_api.Profiles.domain.Repositories;
using easypost_api.Profiles.domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork):IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}