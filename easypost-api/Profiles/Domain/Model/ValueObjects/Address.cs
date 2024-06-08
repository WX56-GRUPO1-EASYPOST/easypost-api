namespace easypost_api.Profiles.domain.model.valueObjects;

public record Address(string Departamento,string Distrito, string Residential)
{
    public Address() : this(string.Empty,string.Empty,string.Empty )
    {
        
    }
    
    public string FullAddress => $"{Departamento} - {Distrito} - {Residential}";
    
}