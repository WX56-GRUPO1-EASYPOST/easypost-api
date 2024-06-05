namespace easypost_api.Profiles.domain.model.valueObjects;

public record Contact(string telefono, string correo)
{
    public Contact() : this(string.Empty,string.Empty)
    {
        
    }
    public string FullContact => $"{telefono} - {correo}";
}