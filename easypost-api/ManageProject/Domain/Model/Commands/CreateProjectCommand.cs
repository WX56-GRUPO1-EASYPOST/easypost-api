namespace easypost_api.ManageProject.Domain.Model.Commands;

public record CreateProjectCommand(
    string Title, 
    string AccesCode, 
    long TotalBudget, 
    long PartialBudget, 
    int LocationId
    );
