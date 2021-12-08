namespace Planets.Domain.ValueObjects;

public class Endonym : ValueObject
{
    public string Value { get; private set; } = string.Empty;
    public string Culture { get; private set; } = string.Empty;

    public Endonym(string value, string culture)
    {
        Value = value;
        Culture = culture;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Culture;
    }
}
