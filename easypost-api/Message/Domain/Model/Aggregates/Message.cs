using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Message.Domain.Model.Commands;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Message.Domain.Model.Aggregates;

public class Message
{
    public int Id { get; }
    public string Subject { get; private set; }
    public string EmailBody { get; private set;  }
    public User Recipient { get; private set; }
    public User Sender { get; private set; }
    public DateTime SentTime { get; private set; }

    public Message()
    {
        this.Subject = string.Empty;
        this.EmailBody = string.Empty;
        this.Recipient = Recipient;
        this.Sender = Sender;
        this.SentTime = DateTime.Now;
    }

    public Message(CreateMessageCommand command)
    {
        this.Subject = command.Subject;
        this.EmailBody = command.EmailBody;
        this.Recipient = command.Recipient;
        this.Sender = command.Sender;
        this.SentTime = DateTime.Now;
    }
    
}