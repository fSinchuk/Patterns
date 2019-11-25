using System;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = Singlton.GetInstance();
            Console.WriteLine(instance);
        }
    }

    public sealed class Singlton
    {
        static Singlton state;
        private Singlton(){ state = new Singlton(); }
        public static Singlton GetInstance() {
            if (state == null)
                state = new Singlton();

            return state;
        }

    }
}
