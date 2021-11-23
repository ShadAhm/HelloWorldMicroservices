namespace Planets.Domain.ValueObjects;

public class Endonym : ValueObject
{
    public string Name { get; private set; }

    public Endonym(string name)
    {
        Name = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }

    public static Endonym FromName(string name)
    {
        return new Endonym(name);
    }
}
