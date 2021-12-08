using Planets.Persistence.Io;
using System.Collections;
using System.Text.Json;

namespace Planets.Persistence;

public class DataFile<T> : IReadOnlyCollection<T>
{
    private string _fileName;
    private T[] _items = new T[1];
    private readonly IDataAccessor _dataAccessor;

    public DataFile(IDataAccessor dataAccessor)
    {
        _fileName = $"{typeof(T).Name}.json";
        _dataAccessor = dataAccessor;
        _items = GetItems();
    }

    private T[] GetItems()
        => JsonSerializer.Deserialize<T[]>(_dataAccessor.ReadFile(), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }) ?? new T[1];

    public int Count => _items.Length;

    public IEnumerator<T> GetEnumerator()
    {
        return new DataFileEnumerator<T>(_items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class DataFileEnumerator<T> : IEnumerator<T>
{
    public T[] _objects;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public DataFileEnumerator(T[] list)
    {
        _objects = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _objects.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    object IEnumerator.Current => Current;

    public T Current
    {
        get
        {
            try
            {
                return _objects[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
