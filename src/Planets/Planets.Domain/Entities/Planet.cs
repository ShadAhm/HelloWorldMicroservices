namespace Planets.Domain.Entities;

public class Planet : Entity
{
    public string Name { get; set; }
    public bool IsDwarf { get; private set; }

    public Planet(string name)
    {
        Name = name;
    }

    public void Demote()
    {
        IsDwarf = true;
    }

    public void Promote()
    {
        IsDwarf = false;
    }
}
