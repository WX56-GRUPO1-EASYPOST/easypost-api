namespace easypost_api.Requests.Domain.Model.ValueObjects;

public record RequestDescription(string Description, string Budget)
{
    public RequestDescription() : this(string.Empty,String.Empty)
    {
        
    }
    
    public string DescriptionText =>$"{Description} - {Budget}";
}