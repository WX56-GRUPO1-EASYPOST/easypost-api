namespace easypost_api.ManageProject.Domain.Model.Commands;

public record CreateProjectCommand(
    string Title,
    long TotalBudget, 
    long PartialBudget, 
    int LocationId
    );
