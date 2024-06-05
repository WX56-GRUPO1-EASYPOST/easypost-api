namespace easypost_api.Profiles.domain.model.commands;

public record CreateProfileCommand(String name, String description, String ruc, 
    String telefono, String correo, String departamento, String distrito, String residencial);