namespace Greetings.Api.Greet;

public class GreetService : IGreetService
{
    public string Execute(string greatee)
        => new GreetingBuilder().ForGreatee(greatee).WithExcitement().ToString();
}
