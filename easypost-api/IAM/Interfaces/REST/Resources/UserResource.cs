namespace easypost_api.IAM.Interfaces.REST.Resources;

public record UserResource(
    int Id, 
    string Username,
    string Type,
    int ProfileId
    );