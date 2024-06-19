namespace easypost_api.IAM.Interfaces.REST.Resources;

//public record AuthenticatedUserResource(int Id, string Username, string Token);
public record AuthenticatedUserResource(int Id, string Username,string Type);