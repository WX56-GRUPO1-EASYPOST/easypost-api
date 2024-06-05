namespace easypost_api.Profiles.Interfaces.REST.resources;

public record CreateProfileResource(string Name, string Description, string Ruc, string Telefono, string Correo, string Departamento, string Distrito, string Residencial);
