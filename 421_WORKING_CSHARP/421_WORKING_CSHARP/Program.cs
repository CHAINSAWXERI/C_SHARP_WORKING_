using System;

//TSK1
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

//TSK2
public class Circle
{
    public int Diameter { get; } = 10;
    public int CenterX { get; } = 5;
    public int CenterY { get; } = 5;

    public virtual void Draw()
    {
        Console.WriteLine($"Drawing circle with diameter {Diameter} at center ({CenterX}, {CenterY})");
    }
}

public class DecoratorCircle : Circle
{
    private Circle _circle;

    public DecoratorCircle(Circle circle)
    {
        _circle = circle;
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing circle at a new location");
    }
}

public class ShiftedCircle : DecoratorCircle
{
    private int _shiftX;
    private int _shiftY;

    public ShiftedCircle(Circle circle) : base(circle)
    {
    }

    public void SetShift(int shiftX, int shiftY)
    {
        _shiftX = shiftX;
        _shiftY = shiftY;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing shifted circle at center ({base.CenterX + _shiftX}, {base.CenterY + _shiftY})");
    }
}

class Program
{
    static void Main()
    {
        //TSK1
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

        //TSK2
        Circle baseCircle = new Circle();

        DecoratorCircle decoratorCircle = new DecoratorCircle(baseCircle);

        ShiftedCircle shiftedCircle = new ShiftedCircle(baseCircle);

        Console.Write("Enter shift value for X: ");
        int shiftX = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter shift value for Y: ");
        int shiftY = Convert.ToInt32(Console.ReadLine());

        shiftedCircle.SetShift(shiftX, shiftY);
        shiftedCircle.Draw();
    }
}
