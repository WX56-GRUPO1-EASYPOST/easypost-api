namespace easypost_api.ManageProject.Domain.Model.Commands;

public record CreateLocationCommand(
    string Department, 
    string Province, 
    string District, 
    string Locality, 
    string Address, 
    string Reference 
    );