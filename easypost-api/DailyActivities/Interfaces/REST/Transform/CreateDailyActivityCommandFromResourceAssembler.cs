using easypost_api.DailyActivities.Domain.Model.Commands;
using easypost_api.DailyActivities.Interfaces.REST.Resources;

namespace easypost_api.DailyActivities.Interfaces.REST.Transform;

public static class CreateDailyActivityCommandFromResourceAssembler
{
    public static CreateDailyActivityCommand ToCommandFromResource(CreateDailyActivityResource resource)
    {
        return new CreateDailyActivityCommand(resource.Name, resource.Description, resource.ProjectId);
    }
}