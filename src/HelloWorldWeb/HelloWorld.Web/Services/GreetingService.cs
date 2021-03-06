namespace HelloWorld.Web.Services;

public interface IGreetingService
{
    Task<string> GetString(string uri);
}

public class GreetingService : IGreetingService
{
    private readonly HttpClient _httpClient;

    public GreetingService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        var path = Path.Combine(configuration["integration:apiGatewayBaseUrl"], "greetings/");
        _httpClient.BaseAddress = new Uri(path);
    }
    
    public async Task<string> GetString(string uri) => await _httpClient.GetStringAsync(uri);
}
