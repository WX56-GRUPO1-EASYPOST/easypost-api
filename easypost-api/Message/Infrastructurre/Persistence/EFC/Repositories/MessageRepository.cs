using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace easypost_api.Message.Infrastructurre.Persistence.EFC.Repositories;

public class MessageRepository(AppDbContext context): BaseRepository<MessageEntity>(context),IMessageRepository
{
    
}