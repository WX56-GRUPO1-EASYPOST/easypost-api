using easypost_api.Poles.Domain.Model.Entities;

namespace easypost_api.Poles.Domain.Model.Aggregates;

public partial class Pole
{
    public Pole()
    {
        Description = null;
        ProjectId = 0;
        GeoReferenceId = 0;
        PolePictures = new List<PolePicture>();
    }
    
    public ICollection<PolePicture> PolePictures { get; }
    
    public void AddPolePicture(string imageUri, string description)
    {
        PolePictures.Add(new PolePicture(imageUri, description));
    }
    
    public void UpdateDescription(string description)
    {
        Description = description;
    }
    
    public void UpdateImgDescription(int polePictureId, string description)
    {
        var polePicture = PolePictures.FirstOrDefault(p => p.Id == polePictureId);
        polePicture?.UpdateDescription(description);
    }
    
    public void RemovePolePicture(int polePictureId)
    {
        var polePicture = PolePictures.FirstOrDefault(p => p.Id == polePictureId);
        if (polePicture != null) PolePictures.Remove(polePicture);
    }
}