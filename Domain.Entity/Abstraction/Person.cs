namespace DAL.Abstraction;

/// <summary>
/// класс описывает человека
/// </summary>
public abstract class Person: BaseEntity,IMyCloneable<Person>, ICloneable
{
    public Person(int id,string firstName, string lastName,int age):base(id) 
    {
        FirstName = firstName;
        LastName = lastName;
        Age=age;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    /// <summary>
    /// поверхностное копипование
    /// </summary>
    /// <returns></returns>
    public abstract Person CustomClone();
    /// <summary>
    /// глубокое копирование
    /// </summary>
    /// <returns></returns>
    public abstract Person DeepClone();
    public abstract object Clone();
}
