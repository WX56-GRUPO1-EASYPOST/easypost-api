namespace easypost_api.IAM.Interfaces.ACL;

public interface IUserContextFacade
{
    Task<bool> ExistsUserId(int userId);
}