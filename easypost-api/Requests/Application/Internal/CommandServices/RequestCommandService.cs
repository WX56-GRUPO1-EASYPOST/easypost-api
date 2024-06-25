using easypost_api.ManageProject.Interfaces.ACL;
using easypost_api.Profiles.Interfaces.ACL;
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
    private readonly IProfilesContextFacade _profilesContextFacade;
    private readonly IProjectContextFacade _projectContextFacade;
    private readonly ILocationContextFacade _locationContextFacade;
    
    public RequestCommandService(IRequestRepository requestRepository, IUnitOfWork unitOfWork,
        IProfilesContextFacade profilesContextFacade, IProjectContextFacade projectContextFacade,
        ILocationContextFacade locationContextFacade)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
        _profilesContextFacade = profilesContextFacade;
        _projectContextFacade = projectContextFacade;
        _locationContextFacade = locationContextFacade;
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

    public async Task<Request?> Handle(CreateRequestByFormCommand command)
    {
        // llamar a facade Profile para validar si existen los clientId y EnterpriseId
        if (!_profilesContextFacade.ExistsProfileById(command.ClientId) ||
            !_profilesContextFacade.ExistsProfileById(command.EnterpriseId))
        {
            return null;
        }
        
        //llamar a facade location para crear, y retornar Id de location
        var locationId = await _locationContextFacade.CreateLocation(command.Department,
            command.Province, command.District, command.Locality, command.Address, command.Reference);
        if (locationId == 0)
        {
            return null;
        }
        
        //llamar a facade project para crear y retornar Id de Project
        var projectId = await _projectContextFacade.CreateProject(command.ProjectTitle,command.Budget,
            command.PartialBudget,locationId.Value);
        if (projectId==0)
        {
            return null;
        }
        
        //llamar a facade de Profile para retornar Entidad Profile de Cliente y Empresa
        var client = await _profilesContextFacade.GetProfileById(command.ClientId);
        var enterprise = await _profilesContextFacade.GetProfileById(command.EnterpriseId);
        if (client==null || enterprise==null)
        {
            return null;
        }
        
        //var createRequestCommand = new CreateRequestCommnad(meter todos los datos necesarios);
        var createRequestCommand = new CreateRequestCommand(command.Description, command.Budget.ToString(),
            projectId.Value, client.Id, enterprise.Id, locationId.Value, command.Deadline);
        var request = await this.Handle(createRequestCommand);
        if (request==null)
        {
            return null;
        }
        //
        /*var project = await _projectContextFacade.GetProjectById(projectId.Value);
        var location = await _locationContextFacade.GetLocationById(locationId.Value);

        request.Project = project;
        request.Location = location;
        request.Client = client;
        request.Enterprise = enterprise;*/
        
        return request;
    }

    public async Task<Request?> Handle(UpdateRequestStatusCommand command)
    {
        var request = await _requestRepository.FindByIdAsync(command.RequestId);
        if (request is null)
        {
            return null;
        }
        request.UpdateStatus(command.Status);
        _requestRepository.Update(request);
        await _unitOfWork.CompleteAsync();
        return request;
    }
}