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
        
        //llamar a facade location para crear, y retornar Id de location
        
        //llamar a facade project para crear y retornar Id de Project
        
        //llamar a facade de Profile para retornar Entidad Profile de Cliente y Empresa
        
        //var createRequestCommand = new CreateRequestCommnad(meter todos los datos necesarios);
        
        //var request = await this.Handle(createRequestCommand);
        //if(request == null) return null;
        //return request;
    }
}