using Planets.Persistence.Io;
using System.Collections;
using System.Text.Json;

namespace Planets.Persistence;

public class DataFile<T> : IReadOnlyCollection<T>, IDataFile<T>
{
    private string _fileName;
    private T[]? _items = new T[0];
    private readonly IDataAccessor _dataAccessor;

    public DataFile(IDataAccessor dataAccessor)
    {
        _fileName = $"{typeof(T).Name}s.json";
        _dataAccessor = dataAccessor;
    }

    public void Initialize()
    {
        _items = JsonSerializer.Deserialize<T[]>(_dataAccessor.ReadFile(_fileName), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    public int Count => _items == null ? 0 : _items.Length;

    public IEnumerator<T> GetEnumerator()
    {
        return new DataFileEnumerator<T>(_items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}