using easypost_api.DailyActivities.Domain.Model.Commands;
using easypost_api.DailyActivities.Interfaces.REST.Resources;

namespace easypost_api.DailyActivities.Interfaces.REST.Transform;

public static class AddDailyActivityPictureCommandFromResourceAssembler
{
    public static AddDailyActivityPictureCommand ToCommandFromResource(AddDailyActivityPictureResource resource, int DailyActivityId)
    {
        return new AddDailyActivityPictureCommand(resource.PictureUrl, resource.Description, DailyActivityId);
    }
}