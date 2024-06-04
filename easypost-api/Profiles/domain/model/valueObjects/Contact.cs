namespace easypost_api.Profiles.domain.model.valueObjects;

public record Contact(String telefono, String correo)
{
    public Contact() : this(string.Empty,string.Empty)
    {
        
    }
}