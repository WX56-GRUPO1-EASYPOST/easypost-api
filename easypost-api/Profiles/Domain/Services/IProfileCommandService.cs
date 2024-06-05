using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.Domain.Model.Commands;

namespace easypost_api.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}