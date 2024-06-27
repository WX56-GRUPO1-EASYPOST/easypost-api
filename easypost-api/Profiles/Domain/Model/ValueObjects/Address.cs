namespace easypost_api.Profiles.domain.model.valueObjects;

public record Address(
    string Department, 
    string District, 
    string Residential
    )
{
    public Address() : this(string.Empty,string.Empty,string.Empty )
    {
        
    }
    
    public string FullAddress => $"{Department} - {District} - {Residential}";
    
}