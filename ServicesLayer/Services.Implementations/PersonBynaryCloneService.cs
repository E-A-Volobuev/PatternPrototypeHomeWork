using DAL.Abstraction;
using ServicesLayer.Services.Abstractions;

namespace ServicesLayer.Services.Implementations;

public class PersonBynaryCloneService : DeepBynaryCloneService<Person>, IPersonBynaryCloneService
{
}
