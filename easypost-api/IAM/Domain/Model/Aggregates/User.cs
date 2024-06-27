using System.Text.Json.Serialization;
using easypost_api.IAM.Domain.Model.ValueObjects;
using easypost_api.Profiles.Domain.Model.Aggregates;

namespace easypost_api.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *     The user aggregate
 * </summary>
 * <remarks>
 *     This class is used to represent a user
 * </remarks>
 */
public class User(string username, string passwordHash, int profileId, EUserType Type)
{
    public User() : this(string.Empty, string.Empty, 0, EUserType.Client)
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;

    public int ProfileId { get; private set; } = profileId;
    
    public Profile Profile { get; private set; } 
    
    public EUserType Type { get; private set; } = Type;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    /**
     * <summary>
     *     Update the username
     * </summary>
     * <param name="username">The new username</param>
     * <returns>The updated user</returns>
     */
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    /**
     * <summary>
     *     Update the password hash
     * </summary>
     * <param name="passwordHash">The new password hash</param>
     * <returns>The updated user</returns>
     */
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}