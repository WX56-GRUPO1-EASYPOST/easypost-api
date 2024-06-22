namespace easypost_api.Requests.Interface.REST.Resources;

public record CreateRequestByFormResource(
    string Description, string Budget,
    int ClientId, int EnterpriseId, DateTime Deadline,
    string Department, string Province, string District, string Address,
    string Locality, string Reference,
    string ProjectTitle, string PartialBudget);