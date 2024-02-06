using DAL.Abstraction;
using Newtonsoft.Json;

namespace DAL.Entities;

/// <summary>
/// владелец компании
/// </summary>
public class CompanyOwner:Person
{
    public Company Company { get; set; }
    public CompanyOwner(int id, Company company, string firstName, string lastName,int age) : base(id, firstName, lastName, age)
    {
        Company = company;
    }
    public override CompanyOwner CustomClone()
    {
        return new CompanyOwner(Id, Company, FirstName, LastName,Age);
    }
    public override object Clone()
    {
        return CustomClone();
    }
    public override CompanyOwner DeepClone()
    {
        CompanyOwner owner = new CompanyOwner(Id, Company, FirstName, LastName, Age);
        string jsonCompanyOwner = JsonConvert.SerializeObject(owner);
        return JsonConvert.DeserializeObject<CompanyOwner>(jsonCompanyOwner);
    }
}
