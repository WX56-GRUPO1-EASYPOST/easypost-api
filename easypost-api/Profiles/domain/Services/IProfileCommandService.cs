using easypost_api.Profiles.domain.model.aggregates;
using easypost_api.Profiles.domain.model.commands;

namespace easypost_api.Profiles.domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}