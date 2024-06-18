using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}