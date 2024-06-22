using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Commands;
using easypost_api.Profiles.domain.model.valueObjects;
using easypost_api.Requests.Domain.Model.Aggregates;

namespace easypost_api.Profiles.Domain.Model.Aggregates;

public partial class Profile
{

    public int Id { get; }
    public int UserId { get; set;}
    public Details Detail { get; private set; }
    public Contact Contact { get; private set; }
    public Address Address { get; private set; }
    
    public User User { get; set; }
    
    public ICollection<Request> ClientRequests { get; set; }
    public ICollection<Request> EnterpriseRequests { get; set; }
    
    public string FullContact => Contact.FullContact;
    public string FullAddress => Address.FullAddress;
    
    public string FullDetails => Detail.FullDetails;
    public Profile()
    {
        Detail = new Details();
        Contact = new Contact();
        Address = new Address();
        UserId=0;
    }

    public Profile(string name, string description, string ruc, string telefono, string correo, string departamento,
        string distrito, string residencial, int userId)
    {
        Detail = new Details(name,description,ruc);
        Contact = new Contact(telefono,correo);
        Address = new Address(departamento,distrito,residencial);
        UserId= userId;
    }
    
    //constructor con command
    public Profile(CreateProfileCommand command)
    {
        Detail = new Details(command.Name,command.Description,command.Ruc);
        Contact = new Contact(command.Telefono,command.Correo);
        Address = new Address(command.Departamento,command.Distrito,command.Residencial);
        UserId = command.UserId;
    }

    //metodos 
    
    public void UpdateDetails(string name, string description, string ruc)
    {
        Detail = new Details(name, description, ruc);
    }

    public void UpdateContact(string telefono, string correo)
    {
        Contact = new Contact(telefono, correo);
    }

    public void UpdateAddress(string departamento, string distrito, string residencial)
    {
        Address = new Address(departamento, distrito, residencial);
    }
}