using System;

namespace CS_20200422
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = new TimerManager("Timer");

            tm.Initialized += Tm_Initialized;

            tm.Initialize();

            Console.WriteLine("Hello World!");
        }

        private static void Tm_Initialized(object sender, EventArgs e)
        {
            Console.WriteLine($"TimeManager inizializzato");
        }
    }
}
