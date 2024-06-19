using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.IAM.Domain.Repositories;

public interface IUserRepository:IBaseRepository<User>
{
    bool ExistsByUsername(string username);
    Task<User?> FindByUsername(string username);
}