namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record CreateLocationResource(
    string Department, 
    string Province, 
    string District, 
    string Locality, 
    string Address, 
    string Reference
    );