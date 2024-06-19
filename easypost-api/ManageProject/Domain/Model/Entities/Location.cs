using easypost_api.ManageProject.Domain.Model.Aggregates;

namespace easypost_api.ManageProject.Domain.Model.Entities;

public class Location
{
    public Location(
        string department, 
        string province, 
        string district, 
        string locality, 
        string address, 
        string reference
        )
    {
        Department = department;
        Province = province;
        District = district;
        Locality = locality;
        Address = address;
        Reference = reference;
    }
    
    public int Id { get; private set; }
    
    public string Department { get; private set; }
    
    public string Province { get; private set; }
 
    public string District { get; private set; }
    
    public string Locality { get; private set; }
    
    public string Address { get; private set; }
    
    public string Reference { get; private set; }
    
    public ICollection<Project> Projects { get; }
}