namespace easypost_api.DailyActivities.Domain.Model.Commands;

public record CreateDailyActivityCommand(string Name, string Description, int ProjectId);