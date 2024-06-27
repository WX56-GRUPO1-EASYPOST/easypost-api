using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Commands;
using easypost_api.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Message.Domain.Model.Aggregates;

public class MessageEntity
{
    public int Id { get; }
    public string Text { get; private set;  }
    public int RecipientId { get; set; }
    public Profile Recipient { get; private set; }
    public int SenderId { get; set; }
    public Profile Sender { get; private set; }
    public DateTime SentTime { get; private set; }

    public MessageEntity()
    {
        
    }

    public MessageEntity(CreateMessageCommand command)
    {
        this.Text = command.Text;
        this.RecipientId = command.RecipientId;
        this.SenderId = command.SenderId;
        this.SentTime = DateTime.Now;
    }
    
}