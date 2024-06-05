using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context):BaseRepository<Profile>(context),IProfileRepository
{
    
}