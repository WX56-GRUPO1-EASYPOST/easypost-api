using easypost_api.Profiles.domain.model.valueObjects;

namespace easypost_api.Profiles.domain.model.aggregates;

public partial class Profile
{

    public int Id { get; }
    public Details Detail { get; private set; }
    public Contact Contact { get; private set; }
    public Address Address { get; private set; }
    
    public Profile()
    {
        Detail = new Details();
        Contact = new Contact();
        Address = new Address();
    }

    public Profile(String name, String description, String ruc, String telefono, String correo, String departamento,
        String distrito, String residencial)
    {
        Detail = new Details(name,description,ruc);
        Contact = new Contact(telefono,correo);
        Address = new Address(departamento,distrito,residencial);
    }
    
    //constructor con command
    
    //metodos 
}