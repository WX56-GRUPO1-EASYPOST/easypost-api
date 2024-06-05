namespace easypost_api.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string Name, string Description, string Ruc, string Telefono, string Correo, string Departamento, string Distrito, string Residencial);
