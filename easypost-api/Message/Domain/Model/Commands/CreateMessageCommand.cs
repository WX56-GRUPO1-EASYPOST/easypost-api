using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Domain.Model.Commands;

public record CreateMessageCommand(string Subject, string EmailBody, User Recipient, User Sender);