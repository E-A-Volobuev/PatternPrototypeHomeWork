namespace DAL.Abstraction;

[Serializable]
public abstract class BaseEntity
{
    public BaseEntity(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
