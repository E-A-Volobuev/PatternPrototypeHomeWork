using DAL.Abstraction;
using DAL.Entities;
using Microsoft.Extensions.Hosting;
using ServicesLayer.Services.Abstractions;

namespace PatternPrototypeHomeWork;

public class Start : BackgroundService
{
    private readonly IPersonBynaryCloneService _employerService;

    public Start(IPersonBynaryCloneService employerService)
    {
        _employerService = employerService ?? throw new ArgumentNullException(nameof(employerService));
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Company company = new Company(1, "Microsoft", 2);
        Person employer = new Employer(1, "Иван", "Иванов", 30, company);
        Person owner = new CompanyOwner(2, company, "Петр", "Петров", 40);
        Person employerClone = employer.CustomClone();
        Person ownerClone = owner.CustomClone();

        object employerObjectClone = employerClone.Clone();
        object ownerObjectClone = ownerClone.Clone();

        object employerObjectDeepClone = employerClone.DeepClone();
        object ownerObjectDeepClone = ownerClone.DeepClone();

        object employerObjectBynaryClone = _employerService.DeepBynaryClone(employerClone);
        object ownerObjectBynaryClone = _employerService.DeepBynaryClone(ownerClone);
    }
}