using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Commands;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Message.Domain.Model.Aggregates;

public class MessageEntity
{
    public int Id { get; }
    public string Subject { get; private set; }
    public string EmailBody { get; private set;  }
    public int RecipientId { get; set; }
    public User Recipient { get; private set; }
    public int SenderId { get; set; }
    public User Sender { get; private set; }
    public DateTime SentTime { get; private set; }

    public MessageEntity()
    {
        
    }

    public MessageEntity(CreateMessageCommand command)
    {
        this.Subject = command.Subject;
        this.EmailBody = command.EmailBody;
        this.RecipientId = command.RecipientId;
        this.SenderId = command.SenderId;
        this.SentTime = DateTime.Now;
    }
    
}