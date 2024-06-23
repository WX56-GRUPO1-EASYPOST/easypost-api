using easypost_api.Message.Domain.Model.Queries;

namespace easypost_api.Message.Domain.Services;

public interface MessageQueryService
{
    Task<Model.Aggregates.Message?> Handle(GetMessageByIdQuery query);
}