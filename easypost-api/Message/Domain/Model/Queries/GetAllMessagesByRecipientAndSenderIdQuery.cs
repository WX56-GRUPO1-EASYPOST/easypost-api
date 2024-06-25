namespace easypost_api.Message.Domain.Model.Queries;

public record GetAllMessagesByRecipientAndSenderIdQuery(int RecipientId, int SenderId);