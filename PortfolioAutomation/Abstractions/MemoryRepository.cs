public class MemoryRepository : IRepository
{
    private readonly Dictionary<Type, object> _data = new();

    public void Add<T>(T value)
    {
        _data[typeof(T)] = value;
    }

    public T Get<T>()
    {
        if (_data.TryGetValue(typeof(T), out var value))
        {
            return (T)value;
        }

        throw new InvalidOperationException($"Data of type {typeof(T)} not found in the repository.");
    }
}
