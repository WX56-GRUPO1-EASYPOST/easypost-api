namespace easypost_api.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial);
}