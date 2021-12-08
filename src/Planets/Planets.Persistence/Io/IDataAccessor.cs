namespace Planets.Persistence.Io;

public interface IDataAccessor
{
    string ReadFile(string fileName);
}
