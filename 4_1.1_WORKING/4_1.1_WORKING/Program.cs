using System.Security.Cryptography.X509Certificates;

namespace TSK1
{
    public class Client
    {
        public void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1, 13);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2, "Ali");
            clone = prototype.Clone();
        }
    }



    public abstract class Prototype
    {
        public int Id;

        public Prototype(int id)
        {
            this.Id = id;
        }

        public abstract Prototype Clone();
    }



    public class ConcretePrototype1 : Prototype
    {
        public int Age;
        
        public ConcretePrototype1(int id, int age) : base(id)
        {
            this.Age = age;
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id, Age);
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public string Name;

        public ConcretePrototype2(int id, string name) : base(id)
        {
            this.Name = name;
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id, Name);
        }

    }
}

namespace TSK2
{
    public abstract class Product
    {
        public int Live;

        public Product(int live)
        {
            Live = live;
        }
    }

    public class ConcreteProductA : Product
    {
        public int DeathDate;

        public ConcreteProductA(int live, int deathDate) : base(live)
        {
            DeathDate = deathDate;
        }
    }

    public class ConcreteProductB : Product
    {
        public string DeathPhase;

        public ConcreteProductB(int live, string deathPhase) : base(live)
        {
            DeathPhase = deathPhase;
        }
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() 
        { 
            return new ConcreteProductA(1, 2); 
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() 
        { 
            return new ConcreteProductB(2, "full"); 
        }
    }
}

namespace TSK3
{
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public abstract class AbstractProductA
    {
        public int x1;
        public int x2;

        public AbstractProductA(int V1, int V2)
        {
            x1 = V1;
            x2 = V2;
        }
    }

    public abstract class AbstractProductB
    {
        public int y1;
        public int y2;

        public AbstractProductB(int V1, int V2)
        {
            y1 = V1;
            y2 = V2;
        }
    }

    public class ProductA1 : AbstractProductA
    {
        public string f;

        public ProductA1(int V1, int V2, string F) : base(V1, V2)
        {
            f = F;
        }
    }

    public class ProductB1 : AbstractProductB
    {
        public bool f;

        public ProductB1(int V1, int V2, bool F) : base(V1, V2)
        {
            f = F;
        }
    }

    public class ProductA2 : AbstractProductA
    {
        public string g;

        public ProductA2(int V1, int V2, string G) : base(V1, V2)
        {
            g = G;
        }
    }

    public class ProductB2 : AbstractProductB
    {
        public bool g;

        public ProductB2(int V1, int V2, bool G) : base(V1, V2)
        {
            g = G;
        }
    }

    public class Client
    {
        private AbstractProductA abstractProductA;
        private AbstractProductB abstractProductB;

        public Client(AbstractFactory factory)
        {
            abstractProductB = factory.CreateProductB();
            abstractProductA = factory.CreateProductA();
        }
    }
}

namespace TSK4
{
    public class Client
    {
        void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
        }
    }

    public class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    public class Product
    {
        List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }
    }

    public class ConcreteBuilder : Builder
    {
        Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("Part A");
        }

        public override void BuildPartB()
        {
            product.Add("Part B");
        }

        public override void BuildPartC()
        {
            product.Add("Part C");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}

namespace TSK5
{
    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton()
        {

        }

        public static Singleton GetInstance => instance;
    }



    public class Client
    {
        public void UseSingleton()
        {
            var singleton = Singleton.GetInstance;
        }
    }
}