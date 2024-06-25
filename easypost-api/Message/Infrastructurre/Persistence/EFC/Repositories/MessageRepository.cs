using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Message.Infrastructurre.Persistence.EFC.Repositories;

public class MessageRepository(AppDbContext context): BaseRepository<MessageEntity>(context),IMessageRepository
{
    public async Task<IEnumerable<MessageEntity>> FindAllByRecipientAndSenderId(int recipientId,int senderId)
    {
        return await context.Set<MessageEntity>()
            .Where(m => m.RecipientId == recipientId && m.SenderId==senderId)
            .ToListAsync();
    }
}