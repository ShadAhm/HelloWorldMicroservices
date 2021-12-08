using Microsoft.Extensions.Options;

namespace Planets.Persistence.Io;

public class DataAccessor : IDataAccessor
{
    private WebHostOptions _options { get; }

    public DataAccessor(IOptions<WebHostOptions> options)
    {
        _options = options.Value;
    }

    public string ReadFile()
    {
        string path = Path.Combine(_options.RootDirectory, @"planets.json");
        return File.ReadAllText(path);
    }
}
