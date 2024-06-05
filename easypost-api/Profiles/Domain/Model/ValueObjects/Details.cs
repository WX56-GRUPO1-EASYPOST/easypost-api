namespace easypost_api.Profiles.domain.model.valueObjects;

public record Details(string name, string description, string ruc)
{
    public Details() : this(string.Empty,string.Empty,string.Empty)
    {
        
    }
    
    public string FullDetails => $"{name} - {description} - {ruc}";
}