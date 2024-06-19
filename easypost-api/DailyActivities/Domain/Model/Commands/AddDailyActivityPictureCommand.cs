namespace easypost_api.DailyActivities.Domain.Model.Commands;

public record AddDailyActivityPictureCommand(string PictureUrl, string Description, int DailyActivityId);