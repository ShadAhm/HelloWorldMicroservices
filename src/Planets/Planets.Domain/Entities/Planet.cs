using Planets.Domain.ValueObjects;

namespace Planets.Domain.Entities;

public class Planet : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDwarf { get; private set; }
    public IEnumerable<Endonym> Endonym { get; set; } = new List<Endonym>();

    public Planet(){}

    public Planet(string name, bool isDwarf)
    {
        Name = name;
        IsDwarf = isDwarf;
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
