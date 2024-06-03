using System;
using System.Collections.Generic;

interface IComponent
{
    bool Explored { get; set; }
    string Description { get; set; }
    string Name { get; set; }

    void Add(IComponent component);
    void Print(int level);
}

class CompositeSkill : IComponent
{
    private List<IComponent> components = new List<IComponent>();

    public bool Explored { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }

    public CompositeSkill(string name, string description, bool explored)
    {
        Name = name;
        Description = description;
        Explored = explored;
    }

    public void Add(IComponent component)
    {
        components.Add(component);
    }

    public void Print(int level)
    {
        string indent = new string('-', level);
        Console.WriteLine($"{indent}{Name} - {Description} - Explored: {Explored}");
        foreach (var component in components)
        {
            component.Print(level + 1);
        }
    }
}

class LeafSkill : IComponent
{
    public bool Explored { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }

    public LeafSkill(string name, string description, bool explored)
    {
        Name = name;
        Description = description;
        Explored = explored;
    }

    public void Add(IComponent component)
    {
        throw new NotImplementedException("Cannot add to a leaf skill");
    }

    public void Print(int level)
    {
        string indent = new string('-', level);
        Console.WriteLine($"{indent}{Name} - {Description} - Explored: {Explored}");
    }
}

class Program
{
    static void Main()
    {
        CompositeSkill tree = new CompositeSkill("Skill Tree", "Main skill tree", false);

        CompositeSkill branch1 = new CompositeSkill("Branch 1", "First branch", false);
        branch1.Add(new LeafSkill("Skill 1.1", "First skill in branch 1", false));
        branch1.Add(new LeafSkill("Skill 1.2", "Second skill in branch 1", true));

        CompositeSkill branch2 = new CompositeSkill("Branch 2", "Second branch", false);
        branch2.Add(new LeafSkill("Skill 2.1", "First skill in branch 2", false));
        branch2.Add(new LeafSkill("Skill 2.2", "Second skill in branch 2", false));

        tree.Add(branch1);
        tree.Add(branch2);

        tree.Print(0);
    }
}
