using ServicesLayer.Services.Abstractions;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServicesLayer.Services.Implementations;

public class DeepBynaryCloneService<T> : IDeepBynaryCloneService<T> where T : class
{
    // Deep clone
    public T DeepBynaryClone(T a)
    {
        using (MemoryStream stream = new MemoryStream())
        {
#pragma warning disable SYSLIB0011
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, a);
            stream.Position = 0;
#pragma warning restore SYSLIB0011
            return (T)formatter.Deserialize(stream);
        }
    }
}