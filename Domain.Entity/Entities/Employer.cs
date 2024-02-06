using DAL.Abstraction;
using Newtonsoft.Json;

namespace DAL.Entities;

/// <summary>
/// сотрудник
/// </summary>
public class Employer: Person
{
    public Company Company { get; set; }
    public Employer(int id, string firstName, string lastName,int age, Company company) :base(id, firstName,lastName,age) 
    {
        Company=company;
    }
    public override Employer CustomClone()
    {
        return new Employer(Id,FirstName,LastName,Age, Company);
    }
    public override object Clone()
    {
        return CustomClone();
    }
    public override Employer DeepClone()
    {
        Employer employer= new Employer(Id, FirstName, LastName, Age, Company);
        string jsonEmployer= JsonConvert.SerializeObject(employer);
        return JsonConvert.DeserializeObject<Employer>(jsonEmployer);
    }
}
