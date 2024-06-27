using easypost_api.Profiles.Domain.Model.Commands;
using easypost_api.Profiles.Domain.Model.Queries;
using easypost_api.Profiles.Domain.Services;

namespace easypost_api.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService)
    : IProfilesContextFacade
{
    //public async Task<int> CreateProfile(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial)
    //{
    //    var command = new CreateProfileCommand(name, description, ruc, telefono, correo, departamento, distrito, residencial);
    //    var profile = await _profileCommandService.Handle(command);
    //    return profile?.Id ?? 0; // Aquí puedes retornar el ID del perfil creado o cualquier otro valor que necesites
    //}

    public async Task<int> CreateProfileForUser(
        string name, 
        string description, 
        string ruc, 
        string phone, 
        string email, 
        string department, 
        string district, 
        string residential
        ) 
    {
        var command = new CreateProfileCommand(
            name, 
            description, 
            ruc, 
            phone, 
            email, 
            department, 
            district, 
            residential
            );
        var profile = await profileCommandService.Handle(command);
        return profile?.Id ?? 0;
    }

    public bool ExistsProfileById(int profileId)
    {
        var query = new ExistProfileByIdQuery(profileId);
        return profileQueryService.Handle(query);
    }
    
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(email);
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}