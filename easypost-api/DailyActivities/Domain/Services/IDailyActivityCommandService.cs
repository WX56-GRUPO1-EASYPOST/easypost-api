using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Model.Commands;

namespace easypost_api.DailyActivities.Domain.Services;

public interface IDailyActivityCommandService
{
    Task<DailyActivity?> Handle(CreateDailyActivityCommand command);
    Task<DailyActivity?> Handle(AddDailyActivityPictureCommand command);
    Task<DailyActivity?> Handle(UpdateDailyActivityPictureDescriptionCommand command);
    Task<DailyActivity?> Handle(DeleteDailyActivityPictureCommand command);
}