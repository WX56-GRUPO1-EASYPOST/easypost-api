using easypost_api.Profiles.Domain.Model.Aggregates;

namespace easypost_api.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    //Task<int> CreateProfile(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial);
    Task<int> CreateProfileForUser(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial, int userId);
    bool ExistsProfileById(int profileId);
    Task<Profile?> GetProfileById(int profileId);
}