namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record CreateProjectResource(
    string Title,
    long TotalBudget, 
    long PartialBudget, 
    int LocationId
    );