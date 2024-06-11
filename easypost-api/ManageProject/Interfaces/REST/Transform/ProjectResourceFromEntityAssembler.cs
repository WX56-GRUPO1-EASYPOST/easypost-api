using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace easypost_api.ManageProject.Interfaces.REST.Transform;

public class ProjectResourceFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Projects project)
    {
        return new ProjectResource(
            project.Id,
            project.Title,
            project.AccessCode,
            project.TotalBudget,
            project.PartialBudget,
            LocationResourceFromEntityAssembler.ToResourceFromEntity(project.Location),
            project.Status.GetDisplayName()
        );
    }
}