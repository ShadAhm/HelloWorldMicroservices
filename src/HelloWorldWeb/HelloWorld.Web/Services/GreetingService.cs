namespace HelloWorld.Web.Services;

public interface IGreetingService
{
    Task<string> Greet();
}

public class GreetingService : IGreetingService
{
    private readonly HttpClient _httpClient;

    public GreetingService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration["integration:greetingsApiBaseUrl"]);
    }

    public async Task<string> Greet()
    {
        return await _httpClient.GetStringAsync("greet?greetee=perl");
    }

}
