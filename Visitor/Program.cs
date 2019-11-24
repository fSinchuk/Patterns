using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();

            calculator.Add(new Bread());
            calculator.Add(new Bread());
            calculator.Add(new Bread());
            calculator.Add(new Milk());

            PriceWithTax pricWithTax = new PriceWithTax();
            calculator.Calculate(pricWithTax);
            Console.WriteLine($"Price with tax {pricWithTax.price}");

            PriceNoTax priceNoTax = new PriceNoTax();
            calculator.Calculate(priceNoTax);
            Console.WriteLine($"Price with no tax {priceNoTax.price}");
        }
    }


    public class Calculator 
    {
        List<Element> list = new List<Element>();
        public void Add(Element el) => list.Add(el);
        public void Calculate(Visitor visitor) 
        {
            foreach (var item in list)
            {
                item.Accept(visitor);
            }
        }
    }

    public abstract class Visitor {
        public abstract void AddBread(Bread b);
        public abstract void AddMilk(Milk m);
    }

    public class PriceWithTax : Visitor
    {
        public double price { get; private set; }
        public override void AddBread(Bread b)
        {
            price += 12*0.18+12;
        }

        public override void AddMilk(Milk m)
        {

            price += 5*0.18+5;
        }

        public override string ToString()
        {
            return price.ToString();
        }
    }
    public class PriceNoTax : Visitor
    {
        public double price { get; private set; }
        public override void AddBread(Bread b)
        {
           price += 12;
        }

        public override void AddMilk(Milk m)
        {
            price += 5;
        }

        public override string ToString()
        {
            return price.ToString();
        }
    }


    public abstract class Element{
        public abstract void Accept(Visitor visitor);
    }
    public class Bread : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.AddBread(this);
        }
    }
    public class Milk : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.AddMilk(this);
        }
    }
}
