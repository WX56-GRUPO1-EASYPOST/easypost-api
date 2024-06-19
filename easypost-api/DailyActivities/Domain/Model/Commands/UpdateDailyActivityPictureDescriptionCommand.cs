namespace easypost_api.DailyActivities.Domain.Model.Commands;

public record UpdateDailyActivityPictureDescriptionCommand(string Description, int DailyActivityPictureId, int DailyActivityId);