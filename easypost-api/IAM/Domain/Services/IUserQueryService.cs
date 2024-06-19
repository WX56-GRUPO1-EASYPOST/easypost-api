using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Queries;

namespace easypost_api.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}