using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Interfaces.REST.Resources;

public record MessageResource(int Id, string Subject, string EmailBody, int RecipientId, int SenderId, string SentTime);