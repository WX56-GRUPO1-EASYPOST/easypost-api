using easypost_api.DailyActivities.Domain.Model.Entities;
using easypost_api.DailyActivities.Domain.Model.ValueObjects;

namespace easypost_api.DailyActivities.Domain.Model.Aggregates;

public partial class DailyActivity
{
    public DailyActivity()
    {
        Name = "";
        Description = "";
        ProjectId = 0;
        DailyActivityPictures = new List<DailyActivityPicture>();
        Status = EActivityStatus.InProgress;
    }
    
    public ICollection<DailyActivityPicture> DailyActivityPictures { get; }
    
    public EActivityStatus Status { get; private set; }
    
    public void AddDailyActivityPicture(string imageUri, string description)
    {
        DailyActivityPictures.Add(new DailyActivityPicture(imageUri, description));
    }
    
    public void UpdateDescription(string description)
    {
        Description = description;
    }
    
    public void UpdateImgDescription(int dailyActivityPictureId, string description)
    {
        var dailyActivityPicture = DailyActivityPictures.FirstOrDefault(p => p.Id == dailyActivityPictureId);
        dailyActivityPicture?.UpdateDescription(description);
    }
    
    public void RemoveDailyActivityPicture(int dailyActivityPictureId)
    {
        var dailyActivityPicture = DailyActivityPictures.FirstOrDefault(p => p.Id == dailyActivityPictureId);
        if (dailyActivityPicture != null) DailyActivityPictures.Remove(dailyActivityPicture);
    }
    
    public void CompleteStatus()
    {
        Status = EActivityStatus.Completed;
    }
    
    public void SuspendedStatus()
    {
        Status = EActivityStatus.Suspended;
    }
}