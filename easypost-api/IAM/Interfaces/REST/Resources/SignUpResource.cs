namespace easypost_api.IAM.Interfaces.REST.Resources;

public record SignUpResource(
    string Username, 
    string Password,
    string Type,
    string Name, 
    string Description, 
    string Ruc, 
    string Phone, 
    string Email, 
    string Department, 
    string District, 
    string Residential
    );