using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Encounter))]
public class EncounterTests
{
    private Dwarf dwarf;
    private Archer archer;
    private Wizard wizard;
    private EvilKnight evilKnight;
    private EvilWizard evilWizard;
    private EvilArcher evilArcher;
    
    [SetUp]
    public void SetUp()
    {
        dwarf = new Dwarf("Dwarf");
        archer = new Archer("Archer");
        wizard = new Wizard("Wizard");
        evilKnight = new EvilKnight("Evil Knight");
        evilWizard = new EvilWizard("Evil Wizard");
        evilArcher = new EvilArcher("Evil Archer");
    }

    [Test]
    public void Test1vs1()
    {
        Encounter encounter = new Encounter(dwarf, evilKnight);
        encounter.DoEncounter();

        int dExpectedLife = 0;
        int eKExpectedLife = 100; //El ataque de dwarf es menor a la defensa del knight
        
        Assert.That(dwarf.Health, Is.EqualTo(dExpectedLife));
        Assert.That(evilKnight.Health,Is.EqualTo(eKExpectedLife));
    }
    
    [Test]
    public void TestOneHeroe()
    { 
        dwarf.AddItem(new Sword());
        
        Encounter encounter = new Encounter(dwarf, evilKnight);
        encounter.AddCharacter(evilWizard);
        encounter.DoEncounter();
        
        int dExpectedLife = 0;
        int eKExpectedLife = 88;
        int eWExpectedLife = 90;
        
        Assert.That(dwarf.Health, Is.EqualTo(dExpectedLife));
        Assert.That(evilKnight.Health,Is.EqualTo(eKExpectedLife));
        Assert.That(evilWizard.Health, Is.EqualTo(eWExpectedLife));
    }

    [Test]
    public void TestMoreEnemies()
    {
        dwarf.AddItem(new Sword());
        archer.AddItem(new Axe());
        
        Encounter encounter = new Encounter(dwarf, evilKnight);
        encounter.AddCharacter(archer);
        encounter.AddCharacter(evilWizard);
        encounter.AddCharacter(evilArcher);
        encounter.DoEncounter();
        
        int dExpectedLife = 0;
        int aExpectedLife = 0;
        int eKExpectedLife = 70;
        int eWExpectedLife = 80;
        int eAExpectedLife = 0;
        
        Assert.That(dwarf.Health,Is.EqualTo(dExpectedLife));
        Assert.That(archer.Health,Is.EqualTo(aExpectedLife));
        Assert.That(evilKnight.Health,Is.EqualTo(eKExpectedLife));
        Assert.That(evilWizard.Health,Is.EqualTo(eWExpectedLife));
        Assert.That(evilArcher.Health,Is.EqualTo(eAExpectedLife));
    }

    [Test]
    public void TestMoreHeroes()
    {
        dwarf.AddItem(new Sword());
        archer.AddItem(new Axe());
        
        Encounter encounter = new Encounter(dwarf, evilKnight);
        encounter.AddCharacter(archer);
        encounter.AddCharacter(wizard);
        encounter.AddCharacter(evilWizard);
        encounter.DoEncounter();

        int dExpectedLife = 56;
        int aExpectedLife = 0;
        int wExpectedLife = 100;
        int eKExpectedLife = 0;
        int eWExpectedLife = 0;
        
        Assert.That(dwarf.Health, Is.EqualTo(dExpectedLife));
        Assert.That(archer.Health,Is.EqualTo(aExpectedLife));
        Assert.That(wizard.Health, Is.EqualTo(wExpectedLife));
        Assert.That(evilKnight.Health,Is.EqualTo(eKExpectedLife));
        Assert.That(evilWizard.Health,Is.EqualTo(eWExpectedLife));
    }

    [Test]
    public void TestInvalidDoEncounter()
    {
        Encounter encounter = new Encounter(evilKnight, evilWizard);
        encounter.DoEncounter();

        int eKExpectedLife = 100;
        int eWExpectedLife = 100;
        
        Assert.That(evilKnight.Health, Is.EqualTo(eKExpectedLife));
        Assert.That(evilWizard.Health, Is.EqualTo(eWExpectedLife));
    }
}