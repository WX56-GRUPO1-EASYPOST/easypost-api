namespace easypost_api.Requests.Domain.Model.ValueObjects;

public record RequestDescription(string Description)
{
    public RequestDescription() : this(string.Empty)
    {
        
    }
    
    public string DescriptionText()
    {
        return Description;
    }
}