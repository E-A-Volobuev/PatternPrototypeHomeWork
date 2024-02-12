namespace ServicesLayer.Services.Abstractions;

public interface IDeepBynaryCloneService<T> where T : class
{
    T DeepBynaryClone(T obj);
}
