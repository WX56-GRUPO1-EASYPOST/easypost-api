namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record CreateProjectResource(
    string Title, 
    string AccesCode, 
    long TotalBudget, 
    long PartialBudget, 
    int LocationId
    );