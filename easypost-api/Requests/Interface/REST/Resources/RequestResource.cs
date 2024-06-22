using easypost_api.ManageProject.Domain.Model.Aggregates;

namespace easypost_api.Requests.Interface.REST.Resources;

public record RequestResource(
    int Id, string Description, string Status,
    int ProjectId, int EnterpriseId, int ClientId,
    string Deadline, int LocationId);