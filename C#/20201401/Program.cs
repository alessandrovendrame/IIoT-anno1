using System;

namespace _20201401
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch;
            Console.Write("Digita un carattere in \"minuscolo\":[ ]\b\b");
            ch=Console.Read();
            if(ch>65 && ch<90)
            {
                Console.Write("Lettera trasformata in maiuscolo: "+(char)toUpper(ch)); 
            }else
            {
                 Console.Write("Lettera trasformata in minuscolo: "+(char)toDown(ch));
            }              
        }

        static int toUpper(int carattere)
        {
            carattere=carattere-32;
            return carattere;
        }

        static int toDown(int car)
        {
            car=car+32;
            return car;
        }
    }
}
