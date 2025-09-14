public interface IRepository
{
    void Add<T>(T value);
    T Get<T>();
}
