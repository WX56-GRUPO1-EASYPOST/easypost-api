using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Requests.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Requests.Application.Internal.CommandServices;

public class RequestCommandService: IRequestCommandService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RequestCommandService(IRequestRepository requestRepository, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Request?> Handle(CreateRequestCommand command)
    {
        var request = new Request(command);
        try
        {
            await _requestRepository.AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return request;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the request: {e.Message}");
            return null;
        }
    }
}