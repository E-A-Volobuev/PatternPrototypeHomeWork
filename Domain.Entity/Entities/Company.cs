using DAL.Abstraction;
namespace DAL.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public int PersonId { get; set; }
    public Company(int id, string name, int personId) : base(id)
    {
        Name = name;
        PersonId=personId;
    }
}
