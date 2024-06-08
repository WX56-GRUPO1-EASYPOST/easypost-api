namespace easypost_api.Profiles.domain.model.valueObjects;

public record Contact(string Telefono, string Correo)
{
    public Contact() : this(string.Empty,string.Empty)
    {
        
    }
    public string FullContact => $"{Telefono} - {Correo}";
}