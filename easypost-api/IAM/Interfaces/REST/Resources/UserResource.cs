namespace easypost_api.IAM.Interfaces.REST.Resources;

public record UserResource(
    int Id, 
    string Username,
    int ProfileId
    );