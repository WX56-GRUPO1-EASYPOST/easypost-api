using easypost_api.Message.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Message.Domain.Repositories;

public interface IMessageRepository:IBaseRepository<MessageEntity>
{
    
}