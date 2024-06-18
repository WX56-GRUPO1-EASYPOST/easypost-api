namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record MaterialResource(
    int Id, 
    string Name, 
    string Description, 
    int Cost);