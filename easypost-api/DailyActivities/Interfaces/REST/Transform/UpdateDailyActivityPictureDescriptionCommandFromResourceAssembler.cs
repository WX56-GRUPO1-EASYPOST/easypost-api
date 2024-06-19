using easypost_api.DailyActivities.Domain.Model.Commands;
using easypost_api.DailyActivities.Interfaces.REST.Resources;

namespace easypost_api.DailyActivities.Interfaces.REST.Transform;

public static class UpdateDailyActivityPictureDescriptionCommandFromResourceAssembler
{
    public static UpdateDailyActivityPictureDescriptionCommand ToCommandFromResource(UpdateDailyActivityPictureDescriptionResource resource, int DailyActivityId)
    {
        return new UpdateDailyActivityPictureDescriptionCommand(
            resource.Description,
            resource.DailyActivityPictureId,
            DailyActivityId
        );
    }
}