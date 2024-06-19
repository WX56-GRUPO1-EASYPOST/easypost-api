using easypost_api.ManageProject.Domain.Model.Commands;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.ManageProject.Application.Internal.CommandServices;

public class LocationCommandService(
    ILocationRepository locationRepository, 
    IUnitOfWork unitOfWork
    ): ILocationCommandService
{
    public async Task<Location?> Handle(CreateLocationCommand command)
    {
        var location = new Location(
            command.Department, 
            command.Province, 
            command.District, 
            command.Locality, 
            command.Address, 
            command.Reference 
            );
        await locationRepository.AddAsync(location);
        await unitOfWork.CompleteAsync();
        return location;
    }
}