namespace easypost_api.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    //Task<int> CreateProfile(string name, string description, string ruc, string telefono, string correo, string departamento, string distrito, string residencial);
    Task<int> CreateProfileForUser(
        string name, 
        string description, 
        string ruc, 
        string phone, 
        string email, 
        string department, 
        string district, 
        string residential,
        string type
        );
    bool ExistsProfileById(int profileId);
    
    Task<int> FetchProfileIdByEmail(string email);
}