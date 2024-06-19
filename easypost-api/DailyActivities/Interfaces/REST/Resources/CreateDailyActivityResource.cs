namespace easypost_api.DailyActivities.Interfaces.REST.Resources;

public record CreateDailyActivityResource(string Description, int ProjectId, string Name);