using easypost_api.Requests.Application.Internal.CommandServices;
using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Model.ValueObjects;
using easypost_api.Requests.Domain.Services;

namespace easypost_api.Requests.Interface.ACL.Services;

public class RequestsContextFacade: IRequestsContextFacade
{
    private readonly IRequestCommandService _requestCommandService;
    
    public RequestsContextFacade(IRequestCommandService requestCommandService)
    {
        _requestCommandService = requestCommandService;
    }
    
    public async Task<int> CreateRequest(string description, int projectId, int enterpriseId,
        int clientId, int locationId, string budget, DateTime deadline)
    {
        var command = new CreateRequestCommand(
            description,budget,projectId,clientId,enterpriseId,locationId,deadline);
        var request = await _requestCommandService.Handle(command);
        return request?.Id ?? 0;
    }
}