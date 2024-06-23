using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.ValueObjects;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Requests.Infrastructure.Persistence.EFC.Repositories;

public class RequestRepository: BaseRepository<Request>, IRequestRepository
{
    private readonly AppDbContext _context;
    
    public RequestRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Request>> FindAllByEnterpriseIdAndStatus(int enterpriseId, ERequestStatus status)
    {
        return await _context.Set<Request>()
            .Where(r => r.EnterpriseId == enterpriseId && r.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Request>> FindAllByClientIdAndStatus(int clientId, ERequestStatus status)
    {
        return await _context.Set<Request>()
            .Where(r => r.ClientId == clientId && r.Status == status)
            .ToListAsync();
    }
}