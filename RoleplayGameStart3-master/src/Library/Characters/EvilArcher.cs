namespace Ucu.Poo.RoleplayGame;

public class EvilArcher: Archer
{
    public EvilArcher(string name):base(name)
    {
        this.name = name;
        this.VP = 2;
    }
}