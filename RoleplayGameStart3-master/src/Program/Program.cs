using System;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        //Crear personajes
        Dwarf vanesa = new Dwarf("Vanesa");
        Wizard isabela = new Wizard("Isabela");
        EvilKnight victoria = new EvilKnight("Victoria");
        EvilArcher ulises = new EvilArcher("Ulises");
        
        //Agregarles items
        vanesa.AddItem(new Sword());
        SpellsBook book1 = new SpellsBook();
        book1.AddSpell(new SpellOne());
        isabela.AddMagicalItem(book1);
        victoria.AddItem(new Bow());
        ulises.AddItem(new Shield());
        
        //Conocer valores de personajes
        Console.WriteLine($"\n({vanesa.Name}) vida: {vanesa.Health}, defensa: {vanesa.DefenseValue}, ataque: {vanesa.AttackValue}");
        Console.WriteLine($"({isabela.Name}) vida: {isabela.Health}, defensa: {isabela.DefenseValue}, ataque: {isabela.AttackValue}");
        Console.WriteLine($"({victoria.Name}) vida: {victoria.Health}, defensa: {victoria.DefenseValue}, ataque: {victoria.AttackValue}");
        Console.WriteLine($"({ulises.Name}) vida: {ulises.Health}, defensa: {ulises.DefenseValue}, ataque: {ulises.AttackValue}\n");
        
        //Crear combate y ejecutarlo
        Encounter firstEncounter = new Encounter(vanesa, victoria);
        firstEncounter.AddCharacter(isabela);
        firstEncounter.AddCharacter(ulises);
        firstEncounter.DoEncounter();
    }
}
