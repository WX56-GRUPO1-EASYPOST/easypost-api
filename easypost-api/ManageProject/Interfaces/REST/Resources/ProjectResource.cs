namespace easypost_api.ManageProject.Interfaces.REST.Resources;

public record ProjectResource(
    int Id,
    string Title,
    long AccessCode,
    long TotalBudget, 
    long PartialBudget,
    LocationResource Location,
    int CompanyProfileId,
    string Status
    );
