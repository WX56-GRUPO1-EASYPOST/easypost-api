using easypost_api.IAM.Domain.Model.Aggregates;

namespace easypost_api.Message.Domain.Model.Commands;

public record CreateMessageCommand(string Text, int RecipientId, int SenderId);