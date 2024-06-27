using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Commands;
using easypost_api.Profiles.Domain.Model.ValueObjects;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Profiles.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profileId = await profileRepository.FindProfileByEmailAsync(command.Email);
        if( profileId != null)
        {
            throw new Exception("Profile already exists");
        }
        
        var type = command.Type switch
        {
            "Client" => EUserType.Client,
            "Company" => EUserType.Company,
            _ => EUserType.None
        };

        if(type == EUserType.None)
            throw new Exception("Invalid user type");
        
        var profile = new Profile(command, type);
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