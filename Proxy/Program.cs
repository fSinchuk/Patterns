using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject s = new Proxy();
            s.Request();
        }
    }


    public abstract class Subject {
        public abstract void Request();
    }


    public class Proxy : Subject
    {
        private RealSubject rSubject;

        public override void Request()
        {
            if (rSubject == null)
                rSubject = new RealSubject();

            rSubject.Request();
        }
    }



    public class RealSubject: Subject {
        public override void Request()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return "Real object request";
        }
    }
}
