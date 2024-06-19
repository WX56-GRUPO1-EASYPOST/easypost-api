using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Model.Commands;
using easypost_api.DailyActivities.Domain.Repositories;
using easypost_api.DailyActivities.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.DailyActivities.Application.Internal.CommandServices;

public class DailyActivityCommandService(
    IDailyActivityRepository dailyActivityRepository,
    IUnitOfWork unitOfWork
    ): IDailyActivityCommandService
{
    public async Task<DailyActivity?> Handle(CreateDailyActivityCommand command)
    {
        var dailyActivity = new DailyActivity(command.Description, command.ProjectId, command.Name);
        await dailyActivityRepository.AddAsync(dailyActivity);
        await unitOfWork.CompleteAsync();
        return dailyActivity;
    }

    public async Task<DailyActivity?> Handle(AddDailyActivityPictureCommand command)
    {
        var dailyActivity = await dailyActivityRepository.FindByIdAsync(command.DailyActivityId);
        if (dailyActivity is null) throw new Exception("DailyActivity not found");
        dailyActivity.AddDailyActivityPicture(command.PictureUrl, command.Description);
        return dailyActivity;
    }

    public async Task<DailyActivity?> Handle(UpdateDailyActivityPictureDescriptionCommand command)
    {
        var dailyActivity = await dailyActivityRepository.FindByIdAsync(command.DailyActivityId);
        if (dailyActivity is null) throw new Exception("DailyActivity not found");
        dailyActivity.UpdateImgDescription(command.DailyActivityPictureId, command.Description);
        return dailyActivity;
    }

    public async Task<DailyActivity?> Handle(DeleteDailyActivityPictureCommand command)
    {
        var dailyActivity = await dailyActivityRepository.FindByIdAsync(command.DailyActivityId);
        if (dailyActivity is null) throw new Exception("DailyActivity not found");
        dailyActivity.RemoveDailyActivityPicture(command.PictureId);
        return dailyActivity;
    }
}