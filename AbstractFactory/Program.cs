using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(new CocaColaFactory());
            c.Run();
        }
    }


    public class Client
    {
        private AbstractBottle bottle;
        private AbstractWater water;

        public Client(AbstractFactory factory)
        {
            this.bottle = factory.CreateBottle();
            this.water = factory.CreateWater();
        }

        public void Run() {
            bottle.Interact(water);
        }
    }

    public class CocaColaFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new CocaColaBottle();
        }

        public override AbstractWater CreateWater()
        {
            return new CocaColaWater();
        }
    }

    public class CocaColaWater : AbstractWater { }
    public class MiniraleWater : AbstractWater { }

    public class CocaColaBottle : AbstractBottle
    {
        public override void Interact(AbstractWater water)
        {
            Console.WriteLine($"CocaCola bottle intract with { water }");
        }
    }
    public class MiniraleBottle : AbstractBottle {
        public override void Interact(AbstractWater water)
        {
            Console.WriteLine($"CocaCola bottle intract with { water }");
        }
    }

    //abstract factory
    public abstract class AbstractFactory {
        public abstract AbstractWater CreateWater();
        public abstract AbstractBottle CreateBottle();
    }
    
    //abstract product
    public abstract class AbstractWater{ }
    public abstract class AbstractBottle {
        public abstract void Interact(AbstractWater p);
    }
}
