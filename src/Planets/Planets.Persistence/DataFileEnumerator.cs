using System.Collections;

namespace Planets.Persistence;

public class DataFileEnumerator<T> : IEnumerator<T>
{
    public T[] _objects;
    int position = -1;

    public DataFileEnumerator(T[]? list)
    {
        _objects = list ?? new T[0];
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
