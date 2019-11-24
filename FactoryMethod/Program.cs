using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
                Developer woodDev = new WoodDeveloper("FGK build");
                House woodHouse = woodDev.Create();

                Developer stoneDev = new StoneDeveloper("IIE house");
                House stoneHouse = stoneDev.Create();
        }
    }



    public abstract class House {}
    public class WoodHouse: House
    {
            public WoodHouse()
            {
                System.Console.WriteLine("Wood house built");
            }
    }
    public class StoneHouse: House
    {
            public StoneHouse()
            {
                System.Console.WriteLine( "Panel house built");
            }
    }


    public abstract class Developer {
        public string Name;
        public abstract House Create();
    }
    public class WoodDeveloper: Developer 
    {
        public WoodDeveloper(string name) {
            base.Name = name;
        }
        public override House Create() => new WoodHouse();
    }
    public class StoneDeveloper: Developer {
        public StoneDeveloper(string name)
        {
            base.Name = name;
        }
        public override House Create() => new StoneHouse();
    }
}
