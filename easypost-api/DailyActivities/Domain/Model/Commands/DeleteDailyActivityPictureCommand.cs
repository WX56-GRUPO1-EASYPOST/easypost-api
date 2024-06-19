namespace easypost_api.DailyActivities.Domain.Model.Commands;

public record DeleteDailyActivityPictureCommand(int DailyActivityId, int PictureId);