namespace easypost_api.Profiles.domain.model.valueObjects;

public record Address(string departamento,string distrito, string residential)
{
    public Address() : this(string.Empty,string.Empty,string.Empty )
    {
        
    }
    
    public string FullAddress => $"{departamento} - {distrito} - {residential}";
    
}