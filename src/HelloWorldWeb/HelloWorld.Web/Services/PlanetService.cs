namespace HelloWorld.Web.Services;

public interface IPlanetService
{
    Task<string> GetString(string uri);
}

public class PlanetService : IPlanetService
{
    private readonly HttpClient _httpClient;

    public PlanetService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        var path = Path.Combine(configuration["integration:apiGatewayBaseUrl"], "planets/");
        _httpClient.BaseAddress = new Uri(path);
    }

    public async Task<string> GetString(string uri) => await _httpClient.GetStringAsync(uri);
}
