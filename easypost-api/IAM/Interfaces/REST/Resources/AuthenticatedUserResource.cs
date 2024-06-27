namespace easypost_api.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(
    int Id, 
    string Username,
    int ProfileId,
    string Token
    );