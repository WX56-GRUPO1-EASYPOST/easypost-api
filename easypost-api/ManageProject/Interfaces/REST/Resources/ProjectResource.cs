namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record ProjectResource(
    int Id,
    string Title, 
    string AccesCode, 
    long TotalBudget, 
    long PartialBudget,
    LocationResource Location,
    string Status
    );
