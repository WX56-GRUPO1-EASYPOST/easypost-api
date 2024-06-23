using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Interfaces.REST.Resources;

public record CreateMessageResource(string Subject, string EmailBody, User Recipient, User Sender, DateTime SentTime);