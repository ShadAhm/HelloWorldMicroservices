namespace Planets.Domain.ValueObjects;

public class Endonym : ValueObject
{
    public string Value { get; private set; } = string.Empty;
    public string Culture { get; private set; } = string.Empty;

    public Endonym(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Culture;
    }

    public static Endonym FromName(string name)
    {
        return new Endonym(name);
    }
}
