using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    private readonly AppDbContext _context = context;

    public bool ExistsById(int profileId)
    {
        return _context.Set<Profile>().Any(profile => profile.Id.Equals(profileId));
    }

    public async Task<Profile?> FindProfileByEmailAsync(string email)
    {
        return await _context.Set<Profile>().FirstOrDefaultAsync(profile => profile.Contact.Email.Equals(email));
    }
}