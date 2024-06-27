namespace easypost_api.Requests.Domain.Model.Commands;

public record CreateRequestByFormCommand(
    string Description, 
    long Budget,
    int ClientProfileId, 
    int CompanyProfileId, 
    DateTime Deadline,
    string Department, 
    string Province, 
    string District, 
    string Address,
    string Locality, 
    string Reference,
    string ProjectTitle, 
    long PartialBudget
    );