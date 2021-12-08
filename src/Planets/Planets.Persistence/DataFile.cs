using Planets.Persistence.Io;
using System.Text.Json;

namespace Planets.Persistence;

public class DataFile<T> : IDataFile<T>
{
    private string _fileName;
    private readonly IDataAccessor _dataAccessor;

    public DataFile(IDataAccessor dataAccessor)
    {
        _fileName = $"{typeof(T).Name}s.json";
        _dataAccessor = dataAccessor;
    }

    public IEnumerable<T> GetAll()
        => JsonSerializer.Deserialize<IEnumerable<T>>(_dataAccessor.ReadFile(_fileName), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }) ?? new List<T>();
}