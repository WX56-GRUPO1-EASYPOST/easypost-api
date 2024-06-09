using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository: BaseRepository<Profile>, IProfileRepository
{
    private readonly AppDbContext _context;
    
    public ProfileRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public bool ExistsById(int profileId)
    {
        return _context.Set<Profile>().Any(profile => profile.Id.Equals(profileId));
    }
}