namespace easypost_api.Profiles.domain.model.valueObjects;

public record Details(string Name, string Description, string Ruc)
{
    public Details() : this(string.Empty,string.Empty,string.Empty)
    {
        
    }
    
    public string FullDetails => $"{Name} - {Description} - {Ruc}";
}