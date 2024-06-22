using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Commands;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Services;

namespace easypost_api.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade : IProfilesContextFacade
{
    private readonly IProfileCommandService _profileCommandService;
    private readonly IProfileQueryService _profileQueryService;
    
    public ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    {
        _profileCommandService = profileCommandService;
        _profileQueryService = profileQueryService;
    }
    
    //public async Task<int> CreateProfile(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial)
    //{
    //    var command = new CreateProfileCommand(name, description, ruc, telefono, correo, departamento, distrito, residencial);
    //    var profile = await _profileCommandService.Handle(command);
    //    return profile?.Id ?? 0; // Aquí puedes retornar el ID del perfil creado o cualquier otro valor que necesites
    //}

    public async Task<int> CreateProfileForUser(string name, string description, string ruc, string telefono,
        string correo, string departamento, string distrito, string residencial, int userId)
    {
        var command = new CreateProfileCommand(name, description, ruc, telefono, correo, departamento, distrito, residencial, userId);
        var profile = await _profileCommandService.Handle(command);
        return profile?.Id ?? 0;
    }

    public bool ExistsProfileById(int profileId)
    {
        var query = new ExistProfileByIdQuery(profileId);
        return _profileQueryService.Handle(query);
    }

    public async Task<Profile?> GetProfileById(int profileId)
    {
        var query = new ExistProfileByIdQuery(profileId);
        if (!_profileQueryService.Handle(query))
        {
            return null;
        }

        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await _profileQueryService.Handle(getProfileByIdQuery);
        if (profile==null)
        {
            return null;
        }

        return profile;
    }
}