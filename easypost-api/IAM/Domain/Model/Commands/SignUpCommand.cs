using easypost_api.IAM.Domain.Model.ValueObjects;

namespace easypost_api.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, EUserType Type);