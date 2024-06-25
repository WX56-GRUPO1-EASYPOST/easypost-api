using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using easypost_api.IAM.Domain.Model.ValueObjects;
using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Aggregates;

namespace easypost_api.IAM.Domain.Model.Aggregates;

public class User
{
    public int Id { get; }
    public string Username { get; private set; }
    
    [JsonIgnore]
    public string Password { get; private set; }
    public EUserType Type { get; private set; }
    
    public Profile Profile { get; set; }

    public ICollection<MessageEntity> RecipientMessages { get; set; }
    public ICollection<MessageEntity> SenderMessages { get; set; }

    public User(string username,string password, EUserType type)
    {
        this.Username = username;
        this.Password = password;
        this.Type = type;
    }
    
    public User()
    {
        this.Username=String.Empty;
        this.Password = string.Empty;
        this.Type = EUserType.Client;
    }
}