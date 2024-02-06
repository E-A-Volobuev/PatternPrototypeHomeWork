using DAL.Abstraction;
using DAL.Entities;
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

        // Act
        #region поверхностное копирование
        Person employerClone = employer.CustomClone();
        Person ownerClone = owner.CustomClone();
        #endregion

        #region глубокое копирование
        Person employerDeepClone = employer.DeepClone();
        Person ownerDeepClone = owner.DeepClone();
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

    }
}
