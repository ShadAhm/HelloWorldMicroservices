namespace Greetings.Api.Greet;

public class GreetingBuilder
{
    private Greeting _greeting = new Greeting();

    public GreetingBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._greeting = new Greeting();
    }

    public GreetingBuilder ForGreatee(string greatee)
    {
        _greeting.Greatee = greatee;
        return this;
    }

    public GreetingBuilder WithExcitement()
    {
        _greeting.IsExcitedMode = true;
        return this;
    }

    public override string ToString()
    {
        string endPunctuation = this._greeting.IsExcitedMode ? "!" : ".";
        return $"Hello, {this._greeting.Greatee}{endPunctuation}";
    }

}