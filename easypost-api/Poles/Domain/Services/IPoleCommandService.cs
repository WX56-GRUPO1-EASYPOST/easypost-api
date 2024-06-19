using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Commands;

namespace easypost_api.Poles.Domain.Services;

public interface IPoleCommandService
{
    Task<Pole?> Handle(CreatePoleCommand command);
    Task<Pole?> Handle(AddPolePictureCommand command);
    Task<Pole?> Handle(UpdatePolePictureDescriptionCommand command);
    Task<Pole?> Handle(DeletePolePictureCommand command);
}