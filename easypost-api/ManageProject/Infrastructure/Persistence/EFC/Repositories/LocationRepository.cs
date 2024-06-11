using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.Shared.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;

public class LocationRepository(AppDbContext context) : BaseRepository<Location>(context), ILocationRepository;