namespace easypost_api.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(
    string Name, 
    string Description, 
    string Ruc, 
    string Phone, 
    string Email, 
    string Department, 
    string District, 
    string Residential,
    string Type
    );
