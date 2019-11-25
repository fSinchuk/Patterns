using System;
using System.Text;

namespace Builder
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Builder woodBuilder = new WoodHouseBuilder();
            Architector arc = new ConcreteArchitector(woodBuilder);
            arc.Construct();
            House house = woodBuilder.GetResult();
            Console.WriteLine(house);
        }
    }


    public class WoodHouseBuilder : Builder
    {
        private House woodHouse;
        private StringBuilder sb = new StringBuilder();

        public WoodHouseBuilder()
        {
            this.woodHouse = new WoodHouse();
        }

        public override House GetResult()
        {
            woodHouse.Status = sb.ToString();
            return woodHouse;
        }

        public override void Biuld(string part) {
            sb.AppendLine(part);       
        }
    }
    public class ConcreteArchitector : Architector
    {
        private string[] houseParts = new string [] {"BaseMents"," 1 Flor","2 Flor","Roof", "Internal works", "Cleaning","House ready" };

        private Builder builder;
        public ConcreteArchitector(Builder builder){
            this.builder = builder;
        }
        public override void Construct()
        {
            foreach (var item in houseParts)
            {
                builder.Biuld(item);
            }
            
        }
    }
    public class WoodHouse : House { }

    public abstract class Architector {
        public abstract void Construct();
    }
    public abstract class Builder {
        public abstract void Biuld(string item);
        public abstract House GetResult();
        
    }
    public abstract class House {
        public string Status { get; set; }
        public override string ToString()
        {
            return Status;
        }
    }
}
