using System;

namespace _20201301
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string text_1 = "Primo programma in C#: ";
            string text_2 = "Buon divertimento!";
            int a=10;
            int b=20;
            Console.WriteLine("{0}{1}", text_1, text_2);
            Console.WriteLine("Stamperò un test condizionale tra a={0} e b={1}: ", a,b);

            if(a<b)
            {
                Console.WriteLine("a<b, VERO!");
            }

            for(int i=0; i<10; i++)
            {
                Console.Write("Passo: " + i);
                Console.WriteLine("--> a=" + a);
            }
        }
    }
}
