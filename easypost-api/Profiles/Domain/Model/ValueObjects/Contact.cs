namespace easypost_api.Profiles.domain.model.valueObjects;

public record Contact(
    string Phone, 
    string Email
    )
{
    public Contact() : this(string.Empty,string.Empty)
    {
        
    }
    public string FullContact => $"{Phone} - {Email}";
}