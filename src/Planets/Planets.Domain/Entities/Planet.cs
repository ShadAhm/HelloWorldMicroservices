using Planets.Domain.ValueObjects;

namespace Planets.Domain.Entities;

public class Planet : Entity
{
    public string Name { get; set; }
    public bool IsDwarf { get; private set; }
    public Endonym? Endonym { get; set; }

    public Planet(){}

    public Planet(string name, bool isDwarf, string? endonym = null)
    {
        Name = name;
        IsDwarf = isDwarf;
        Endonym = endonym == null ? null : new Endonym(endonym);
    }

    public void Demote()
    {
        IsDwarf = true;
    }

    public void Promote()
    {
        IsDwarf = false;
    }

    public bool HasEndonym() => Endonym != null;
}
