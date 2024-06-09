using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Requests.Infrastructure.Persistence.EFC.Repositories;

public class RequestRepository: BaseRepository<Request>, IRequestRepository
{
    private readonly AppDbContext _context;
    
    public RequestRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}