using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Interfaces.REST.Resources;

public record CreateMessageResource(string Subject, string EmailBody, int RecipientId, int SenderId);