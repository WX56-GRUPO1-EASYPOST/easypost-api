using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.domain.model.commands;
using easypost_api.Profiles.domain.Repositories;
using easypost_api.Profiles.domain.Services;

namespace easypost_api.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService: IProfileCommandService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await _profileRepository.AddAsync(profile);
            await _unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}