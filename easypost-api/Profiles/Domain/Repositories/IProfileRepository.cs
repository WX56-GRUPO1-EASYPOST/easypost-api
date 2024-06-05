using System.ComponentModel.DataAnnotations;
using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Shared.Domain.Repositories;

namespace easypost_api.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    
}