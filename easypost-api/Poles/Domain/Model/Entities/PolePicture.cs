namespace easypost_api.Poles.Domain.Model.Entities;

public partial class PolePicture
{
    private PolePicture() {}
    public PolePicture(string imageUri, string description)
    {
        ImageUri = new Uri(imageUri);
        Description = description;
    }

    public int Id { get; }
    public Uri? ImageUri { get; }
    public string Description { get; private set; }
    
    public void UpdateDescription(string description)
    {
        Description = description;
    }
}