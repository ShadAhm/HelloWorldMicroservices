using Microsoft.Extensions.Options;

namespace Planets.Persistence.Io;

public class DataAccessor : IDataAccessor
{
    private WebHostOptions _options { get; }

    public DataAccessor(IOptions<WebHostOptions> options)
    {
        _options = options.Value;
    }

    public string ReadFile(string fileName)
    {
        string path = Path.Combine(_options.RootDirectory, fileName);
        return File.ReadAllText(path);
    }
}
