using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Interfaces.REST.Resources;

public record CreateMessageResource(string Text, int RecipientId, int SenderId);