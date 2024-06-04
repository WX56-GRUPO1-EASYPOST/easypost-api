namespace easypost_api.Profiles.domain.model.valueObjects;

public record Address(String departamento,String distrito, String residential)
{
    public Address() : this(String.Empty,String.Empty,String.Empty )
    {
        
    }
}