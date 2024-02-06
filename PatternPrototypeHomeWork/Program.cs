using DAL.Abstraction;
using DAL.Entities;

Company company = new Company(1, "Microsoft", 2);
Person employer = new Employer(1, "Иван", "Иванов",30, company);
Person owner = new CompanyOwner(2,company, "Петр", "Петров",40);
Person employerClone=employer.CustomClone();
Person ownerClone = owner.CustomClone();

object employerObjectClone=employerClone.Clone();
object ownerObjectClone = ownerClone.Clone();

