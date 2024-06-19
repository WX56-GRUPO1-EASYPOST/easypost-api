using easypost_api.DailyActivities.Domain.Model.Commands;
using easypost_api.DailyActivities.Interfaces.REST.Resources;

namespace easypost_api.DailyActivities.Interfaces.REST.Transform;

public static class DeleteDailyActivityPictureCommandFromResourceAssembler
{
    public static DeleteDailyActivityPictureCommand ToCommandFromResource(DeleteDailyActivityPictureResource resource, int DailyActivityId)
    {
        return new DeleteDailyActivityPictureCommand(
            resource.PictureId,
            DailyActivityId
        );
    }
}