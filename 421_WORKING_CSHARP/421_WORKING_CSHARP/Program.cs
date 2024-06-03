using System;

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public string Race { get; set; }
    public string Ability { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Health: {Health}, Mana: {Mana}, Race: {Race}, Ability: {Ability}";
    }
}

public class Orc : Character
{
    public Orc(Character character)
    {
        Name = character.Name;
        Health = character.Health;
        Mana = character.Mana;
        Race = "Orc";
        Ability = character.Ability + ", Berserk";
    }
}

public class Wizard : Character
{
    public Wizard(Character character)
    {
        Name = character.Name;
        Health = character.Health;
        Mana = character.Mana;
        Race = character.Race;
        Ability = character.Ability + ", CastSpell";
    }

    public Effect CastSpell(Spell spell)
    {
        return new Effect();
    }
}


public class Warlock : Character
{
    public Warlock(Character character)
    {
        Name = character.Name;
        Health = character.Health;
        Mana = character.Mana;
        Race = character.Race;
        Ability = character.Ability + ", SummonMinion";
    }

    public Minion SummonMinion()
    {
        return new Minion();
    }
}


public class Spell { }
public class Effect { }
public class Minion { }

class Program
{
    static void Main()
    {
        Character baseCharacter = new Character
        {
            Name = "Grom",
            Health = 100,
            Mana = 50,
            Race = "Orc",
            Ability = "Axe Swing"
        };

        Orc orcCharacter = new Orc(baseCharacter);

        Wizard wizardCharacter = new Wizard(baseCharacter);

        Warlock warlockCharacter = new Warlock(baseCharacter);

        Console.WriteLine("Base Character:");
        Console.WriteLine(baseCharacter);

        Console.WriteLine("\nOrc Character:");
        Console.WriteLine(orcCharacter);

        Console.WriteLine("\nWizard Character:");
        Console.WriteLine(wizardCharacter);

        Console.WriteLine("\nWarlock Character:");
        Console.WriteLine(warlockCharacter);
    }
}
