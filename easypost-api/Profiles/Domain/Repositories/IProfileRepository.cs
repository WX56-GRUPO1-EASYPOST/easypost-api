//using System.ComponentModel.DataAnnotations;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    bool ExistsById(int profileId);
    Task<Profile?> FindProfileByEmailAsync(string email);
}