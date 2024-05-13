namespace TSK1
{
    public class Client
    {
        public void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();
        }
    }



    public abstract class Prototype
    {
        public int Id { get; private set; }
        public Prototype(int id)
        {
            this.Id = id;
        }

        public abstract Prototype Clone();
    }



    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }

    }
}

namespace TSK2
{
    public abstract class Product
    {
        public int live;
    }

    public class ConcreteProductA : Product
    {
        public int live;
        public int deathDate;
    }

    public class ConcreteProductB : Product
    {
        public int live;
        public int deathPhase;
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductA(); }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductB(); }
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

    }

    public abstract class AbstractProductB
    {

    }

    public class ProductA1 : AbstractProductA
    {

    }

    public class ProductB1 : AbstractProductB
    {

    }

    public class ProductA2 : AbstractProductA
    {

    }

    public class ProductB2 : AbstractProductB
    {

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
        public void Run()
        {

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