namespace easypost_api.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(
        string username, 
        string password,
        string type,
        string name, 
        string description, 
        string ruc, 
        string phone, 
        string email, 
        string department, 
        string district, 
        string residential
        );
    Task<int> FetchUserIdByUsername(string username);
    Task<string> FetchUsernameByUserId(int userId);
    
    Task<bool> UserExistsByUserId(int userId);
    
}