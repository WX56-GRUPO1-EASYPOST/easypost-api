using easypost_api.IAM.Domain.Model.ValueObjects;

namespace easypost_api.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password, EUserType Type, string Name);