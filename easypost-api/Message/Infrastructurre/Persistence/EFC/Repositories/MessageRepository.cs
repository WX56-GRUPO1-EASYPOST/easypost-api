using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Message.Infrastructurre.Persistence.EFC.Repositories;

public class MessageRepository(AppDbContext context): BaseRepository<Domain.Model.Aggregates.Message>(context),Domain.Repositories.MessageRepository
{
    
}