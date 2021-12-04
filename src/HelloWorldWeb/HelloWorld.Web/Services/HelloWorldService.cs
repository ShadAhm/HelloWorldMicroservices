namespace HelloWorld.Web.Services;

public interface IHelloWorldService
{
    Task<string> GetHello();
}

public class HelloWorldService : IHelloWorldService
{
    private readonly IGreetingService _greetingService;

    public HelloWorldService(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public async Task<string> GetHello() => await _greetingService.Greet();
}