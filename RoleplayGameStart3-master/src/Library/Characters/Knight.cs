namespace Ucu.Poo.RoleplayGame;

public class Knight : Character
{
    public Knight(string name):base(name)
    {
        this.name = name;
        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }

}