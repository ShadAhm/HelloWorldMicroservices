using Planets.Domain.ValueObjects;

namespace Planets.Domain.Entities;

public class Planet : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDwarf { get; private set; }
    public IEnumerable<Endonym> Endonyms { get; set; } = new List<Endonym>();
    public string LinguaFrancaCulture { get; set; } = string.Empty;

    public Planet(){}

    public Planet(string name, bool isDwarf, string linguaFrancaCulture)
    {
        Name = name;
        IsDwarf = isDwarf;
        LinguaFrancaCulture = linguaFrancaCulture;
    }

    public void Demote()
    {
        IsDwarf = true;
    }

    public void Promote()
    {
        IsDwarf = false;
    }

    public bool HasEndonym() => Endonyms != null;
}
