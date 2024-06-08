using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.IAM.Infrastructurre.Persistence.EFC.Repositories;

public class UserRepository:BaseRepository<User>,IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Set<User>().Any(user => user.Username.Equals(username));
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }
}