namespace HelloWorld.Web.Services;

public interface IHelloWorldService
{
    Task<string> GetHello();
}

public class HelloWorldService : IHelloWorldService
{
    private readonly IGreetingService _greetingService;
    private readonly IPlanetService _planetService;

    public HelloWorldService(IGreetingService greetingService, IPlanetService planetService)
    {
        _greetingService = greetingService;
        _planetService = planetService;
    }

    public async Task<string> GetHello()
    {
        // TODO: get name of planet as send to greeting service
        var planets = await _planetService.GetString("api/Planet");

        return await _greetingService.GetString("greet?greetee=world");
    }
}