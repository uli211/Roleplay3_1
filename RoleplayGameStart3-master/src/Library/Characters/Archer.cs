namespace Ucu.Poo.RoleplayGame;

public class Archer: Character
{
    public Archer(string name):base(name)
    {
        this.name = name;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}
