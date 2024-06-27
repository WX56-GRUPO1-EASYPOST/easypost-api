namespace easypost_api.Requests.Interface.REST.Resources;

public record CreateRequestByFormResource(
    string ProjectTitle,string Description, long Budget, long PartialBudget,
    int ClientProfileId, int CompanyProfileId, DateTime Deadline,
    string Department, string Province, string District, string Address,
    string Locality, string Reference);