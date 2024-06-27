using easypost_api.Requests.Application.Internal.OutboundServices.ACL;
using easypost_api.Requests.Domain.Model.Aggregates;
using easypost_api.Requests.Domain.Model.Commands;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Requests.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Requests.Application.Internal.CommandServices;

public class RequestCommandService(
    IRequestRepository requestRepository,
    IUnitOfWork unitOfWork,
    IExternalRequestProfileService externalRequestProfileService,
    IExternalRequestProjectService externalRequestProjectService,
    IExternalRequestLocationService externalRequestLocationService)
    : IRequestCommandService
{
    public async Task<Request?> Handle(CreateRequestCommand command)
    {
        var request = new Request(command);
        try
        {
            await requestRepository.AddAsync(request);
            await unitOfWork.CompleteAsync();
            return request;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the request: {e.Message}");
            return null;
        }
    }

    public async Task<Request?> Handle(CreateRequestByFormCommand command)
    {
 
        if (!externalRequestProfileService.ProfileExists(command.ClientId) || 
            !externalRequestProfileService.ProfileExists(command.EnterpriseId))
        {
            return null;
        }
        
        var locationId = await externalRequestLocationService.CreateLocation(command.Department, command.Province,
            command.District, command.Locality,command.Address, command.Reference);
        if (locationId == 0) return null;
        
        var projectId = await externalRequestProjectService.CreateProject(command.ProjectTitle, command.Budget,
            command.PartialBudget, locationId.Value);
        if (projectId == 0) return null;
        
        var createRequestCommand = new CreateRequestCommand(command.Description, command.Budget.ToString(),
            projectId.Value,command.ClientId, command.EnterpriseId, locationId.Value, command.Deadline);
        var request = await this.Handle(createRequestCommand);
        if (request==null)
        {
            return null;
        }
        
        return request;
    }

    public async Task<Request?> Handle(UpdateRequestStatusCommand command)
    {
        var request = await requestRepository.FindByIdAsync(command.RequestId);
        if (request is null)
        {
            return null;
        }
        request.UpdateStatus(command.Status);
        requestRepository.Update(request);
        await unitOfWork.CompleteAsync();
        return request;
    }
}