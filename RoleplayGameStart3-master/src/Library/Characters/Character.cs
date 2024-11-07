namespace Ucu.Poo.RoleplayGame;

public abstract class Character
{

    public Character(string name)
    {
        this.name = name;
    }

    protected string name;
    protected int victoryPoints;
    public string Name
    {
        get
        {
            return this.name;
        }
    }
    protected int health = 100;

    protected List<Item> items = new List<Item>();
    public int VP
    {
        get
        {
            return this.victoryPoints;
        }
        set
        {
            this.victoryPoints = value;
        }
    }
    public int Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public virtual int AttackValue
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
            return value;
        }
    }
    
    public virtual int DefenseValue
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
            return value;
        }
    }

    public void AddItem(Item item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        this.items.Remove(item);
    }

   public void Cure()
   {
       this.Health = 100;
   }

   public void ReceiveAttack(int power)
   {
       if (this.DefenseValue < power)
       {
           this.Health -= power - this.DefenseValue;
       }
   }
}