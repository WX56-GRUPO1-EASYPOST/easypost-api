using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Interfaces.REST.resources;

namespace easypost_api.Requests.Interface.REST.Resources;

public record RequestResource(
    int Id, string Description, string Status,
    int ProjectId, int EnterpriseId, int ClientId,
    string Deadline, int LocationId);