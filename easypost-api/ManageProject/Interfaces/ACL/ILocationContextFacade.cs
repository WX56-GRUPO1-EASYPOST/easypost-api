using easypost_api.ManageProject.Domain.Model.Entities;

namespace easypost_api.ManageProject.Interfaces.ACL;

public interface ILocationContextFacade
{
    Task<int?> CreateLocation(string department, string province,
        string district, string locality, string address, string reference );

    Task<Location?> GetLocationById(int locationId);
}