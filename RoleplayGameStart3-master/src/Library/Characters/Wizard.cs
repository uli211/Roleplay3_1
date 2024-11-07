namespace Ucu.Poo.RoleplayGame;
public class Wizard: Character 

{
    private List<MagicalItem> magicalItems = new List<MagicalItem>();

    public Wizard(string name):base(name)
    {
        this.name = name;
        this.AddMagicalItem(new Staff());
    }

    public override int AttackValue
    {
        get
        {
            int value = 0;
            foreach (Item item in this.items)
            {
                if (item is AttackItem)
                {
                    value += (item as AttackItem).AttackValue;
                }
            }
            foreach (MagicalItem item in this.magicalItems)
            { 
                value += item.AttackValue;
            }
            return value;
        }
    }
    public override int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (Item item in this.items)
            {
                if (item is DefenseItem)
                {
                    value += (item as DefenseItem).DefenseValue;
                }
            }
            foreach (MagicalItem item in this.magicalItems)
            {
                value += item.DefenseValue;
            }
            return value;
        }
    }
    public void AddMagicalItem(MagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveMagicalItem(MagicalItem item)
    {
        this.magicalItems.Remove(item);
    }

}