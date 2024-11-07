namespace Ucu.Poo.RoleplayGame;

public class Encounter
{
    private bool end = false;
    private List<Character> heroes = new List<Character>();
    private List<Character> enemies = new List<Character>();

    public Encounter(Character heroe, Character enemy)
    {
        if (heroe is EvilDwarf || heroe is EvilArcher ||
            heroe is EvilWizard || heroe is EvilKnight)
        {
            enemies.Add(heroe);
            Console.WriteLine($"\nSe ha agregado al enemigo {heroe.Name} en donde se requería un héroe.");
            Console.WriteLine("Debe haber al menos un héroe y un enemigo para realizar un combate.\n");
        }
        else
        {
            heroes.Add(heroe);
        }

        if (enemy is EvilDwarf || enemy is EvilArcher ||
            enemy is EvilWizard || enemy is EvilKnight)
        {
            enemies.Add(enemy);
        }
        else
        {
            heroes.Add(enemy);
            Console.WriteLine($"\nSe ha agregado al héroe {enemy.Name} en donde se requería un enemigo.");
            Console.WriteLine("Debe haber al menos un héroe y un enemigo para realizar un combate.\n");
        }
    }
    
    public void AddCharacter(Character character)
    {
        if (character is EvilDwarf || character is EvilArcher || 
            character is EvilWizard || character is EvilKnight)
        {
            enemies.Add(character);
        }
        else {heroes.Add(character);}
        Console.WriteLine($"\nSe ha agregado a {character.Name} al combate.\n");
    }

    public void DoEncounter()
    {
        if (heroes.Count == 0 || enemies.Count == 0)
        {
            Console.WriteLine("\nERROR:");
            Console.WriteLine("\tNo se ha podido concretar el combate.");
            Console.WriteLine("\tNo hay suficientes héroes/enemigos.\n");
        }
        else
        {
            Console.WriteLine("\nINICIO DEL COMBATE:\n");
            while (this.end == false)
            {
                Console.WriteLine("Ataque Enemigo:");
                if (heroes.Count == 1)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        int hHealth = heroes[0].Health;
                        heroes[0].ReceiveAttack(enemies[i].AttackValue);
                        Console.WriteLine($"\t{enemies[i].Name} atacó a {heroes[0].Name}.");
                        if (heroes[0].Health == hHealth)
                        {
                            Console.WriteLine($"\tNo logró sacarle vida.");
                        }
                        Console.WriteLine($"\tLa nueva vida de {heroes[0].Name} es de {heroes[0].Health}.\n");
                        if (heroes[0].Health == 0)
                        {
                            Console.WriteLine($"\t{heroes[0].Name} ha muerto.\n");
                            heroes.Remove(heroes[0]);
                        }
                        
                    }
                }
                else if (heroes.Count < enemies.Count)
                {
                    for (int i = 0; i < heroes.Count; i++)
                    {
                        int hHealth = heroes[i].Health;
                        heroes[i].ReceiveAttack(enemies[i+1].AttackValue);
                        Console.WriteLine($"\t{enemies[i+1].Name} atacó a {heroes[i].Name}.");
                        if (heroes[i].Health == hHealth)
                        {
                            Console.WriteLine($"\tNo logró sacarle vida.");
                        }
                        Console.WriteLine($"\tLa nueva vida de {heroes[i].Name} es de {heroes[i].Health}.\n");
                        if (heroes[i].Health == 0)
                        {
                            Console.WriteLine($"\t{heroes[i].Name} ha muerto.\n");
                            heroes.Remove(heroes[i]);
                        }
                    }
                }
                else if (heroes.Count >= enemies.Count)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        int hHealth = heroes[i].Health;
                        heroes[i].ReceiveAttack(enemies[i].AttackValue);
                        Console.WriteLine($"\t{enemies[i].Name} atacó a {heroes[i].Name}.");
                        if (heroes[i].Health == hHealth)
                        {
                            Console.WriteLine($"\tNo logró sacarle vida.");
                        }
                        Console.WriteLine($"\tLa nueva vida de {heroes[i].Name} es de {heroes[i].Health}.\n");
                        if (heroes[i].Health == 0)
                        {
                            Console.WriteLine($"\t{heroes[i].Name} ha muerto.\n");
                            heroes.Remove(heroes[i]);
                            if (heroes.Count > 0) {i-=-1;}
                        }
                    } 
                }
                if (heroes.Count == 0)
                {
                    this.end = true;
                    Console.WriteLine("\nFIN DEL COMBATE: Ganaron los enemigos.");
                }
                else
                {
                    Console.WriteLine("Ataque de Héroes:");
                    for (int i = 0; i < heroes.Count;i++)
                    {
                        for (int j = 0; j < enemies.Count; j++)
                        {
                            int eHealth = enemies[j].Health;
                            enemies[j].ReceiveAttack(heroes[i].AttackValue);
                            Console.WriteLine($"\t{heroes[i].Name} atacó a {enemies[j].Name}.");
                            if (enemies[j].Health == eHealth)
                            {
                                Console.WriteLine($"\tNo logró sacarle vida.");
                            }
                            Console.WriteLine($"\tLa nueva vida de {enemies[j].Name} es de {enemies[j].Health}.\n");
                            if (enemies[j].Health == 0)
                            {
                                heroes[i].VP += enemies[j].VP;
                                Console.WriteLine($"\t{enemies[j].Name} ha muerto.");
                                Console.WriteLine($"\t{heroes[i].Name} ha adquirido {enemies[j].VP} puntos de victoria.");
                                Console.WriteLine($"\t{heroes[i].Name} posee actualmente {heroes[i].VP} puntos de victoria.\n");
                                enemies.Remove(enemies[j]);
                                j -= 1;
                                if (heroes[i].VP >= 5)
                                {
                                    heroes[i].Cure();
                                    Console.WriteLine($"\t{heroes[i].Name} se ha curado. Su vida actual es de {heroes[i].Health}.\n");
                                }
                            }
                        }
                    }
                    if (enemies.Count == 0)
                    {
                        this.end = true;
                        Console.WriteLine("\nFIN DEL COMBATE: Ganaron los héroes.");
                    }
                }
            }
            
        }
    }
}