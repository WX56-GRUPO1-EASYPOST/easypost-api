using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Model.Commands;

namespace easypost_api.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}