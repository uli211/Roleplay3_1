namespace Ucu.Poo.RoleplayGame;

public class SpellsBook: MagicalItem
{
    private List<Spell> spells = new List<Spell>();
    public override int AttackValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.spells)
            {
                value += spell.AttackValue;
            }
            return value;
        }
    }
    public override int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.spells)
            {
                value += spell.DefenseValue;
            }
            return value;
        }
    }

    public void AddSpell(Spell spell)
    {
        this.spells.Add(spell);
    }

    public void RemoveSpell(Spell spell)
    {
        this.spells.Remove(spell);
    }
}