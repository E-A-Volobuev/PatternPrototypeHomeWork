using DAL.Abstraction;
using DAL.Entities;
using ServicesLayer.Services.Implementations;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Tests;

public class TestCloneable
{
    public TestCloneable() { }
    [Fact]
    public void CustomCloneableTest()
    {
        //Arrange
        Company company = new Company(1, "Microsoft", 2);
        Person employer = new Employer(1, "Иван", "Иванов", 30,company);
        Person owner = new CompanyOwner(2, company, "Петр", "Петров", 40);
        var service = new PersonBynaryCloneService();

        // Act
        #region поверхностное копирование
        Person employerClone = employer.CustomClone();
        Person ownerClone = owner.CustomClone();
        #endregion

        #region глубокое копирование
        Person employerDeepClone = employer.DeepClone();
        Person ownerDeepClone = owner.DeepClone();
        #endregion

        #region глубокое бинарное копирование
        Person employerDeepBynaryClone = service.DeepBynaryClone(employer);
        Person ownerDeepBynaryClone = service.DeepBynaryClone(owner);
        #endregion

        // Assert;
        #region поверхностное копирование
        Assert.Equal(employerClone.FirstName, employer.FirstName);
        Assert.Equal(employerClone.LastName, employer.LastName);
        Assert.Equal(employerClone.Age, employer.Age);

        Assert.Equal(ownerClone.FirstName, owner.FirstName);
        Assert.Equal(ownerClone.LastName, owner.LastName);
        Assert.Equal(ownerClone.Age, owner.Age);
        #endregion

        #region глубокое копирование
        Assert.Equal(employerDeepClone.FirstName, employer.FirstName);
        Assert.Equal(employerDeepClone.LastName, employer.LastName);
        Assert.Equal(employerDeepClone.Age, employer.Age);

        Assert.Equal(ownerDeepClone.FirstName, owner.FirstName);
        Assert.Equal(ownerDeepClone.LastName, owner.LastName);
        Assert.Equal(ownerDeepClone.Age, owner.Age);
        #endregion

        #region глубокое бинарное копирование
        Assert.Equal(employerDeepClone.FirstName, employer.FirstName);
        Assert.Equal(employerDeepClone.LastName, employer.LastName);
        Assert.Equal(employerDeepClone.Age, employer.Age);

        Assert.Equal(ownerDeepClone.FirstName, owner.FirstName);
        Assert.Equal(ownerDeepClone.LastName, owner.LastName);
        Assert.Equal(ownerDeepClone.Age, owner.Age);
        #endregion
    }

    private Person ClonePerson(Person person)
    {
        if (person != null)
        {
            using (MemoryStream stream = new MemoryStream())
            {
#pragma warning disable SYSLIB0011
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, person);
                stream.Position = 0;
#pragma warning restore SYSLIB0011
                return (Person)formatter.Deserialize(stream);
            }
        }
        return person;
    }
}
