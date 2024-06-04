namespace easypost_api.Profiles.domain.model.valueObjects;

public record Details(String name, String description, String ruc)
{
    public Details() : this(string.Empty,string.Empty,string.Empty)
    {
        
    }
}