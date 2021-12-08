namespace Planets.Persistence
{
    public interface IDataFile<T>
    {
        IEnumerable<T> GetAll();
    }
}