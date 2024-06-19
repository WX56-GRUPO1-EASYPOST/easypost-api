using easypost_api.Poles.Domain.Model.Entities;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Poles.Infrastructure.Persistence.EFC.Repositories;

public class GeoReferenceRepository(
        AppDbContext context
    ): BaseRepository<GeoReference>(context), IGeoReferenceRepository;