namespace easypost_api.Profiles.Interfaces.REST.resources;

public record CreateProfileResource(
    string Name, 
    string Description, 
    string Ruc, 
    string Phone, 
    string Email, 
    string Department, 
    string District, 
    string Residential
    );
