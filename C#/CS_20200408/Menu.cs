using System;

namespace CS_20200408
{
    public class Menu
    {
        private int scelta;

        public Menu(){}

        public int showMenu(){
            Console.WriteLine("Menu:");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Disegna rettagolo vuoto");
            Console.WriteLine("2. Disegna rettangolo pieno");
            Console.WriteLine("3. Scegli figura da disegnare");
            Console.WriteLine("4. Salva");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());

            return scelta;
        }

        public int showFigure(){

            Console.WriteLine("Menu figure:");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Disegna un rettangolo");
            Console.WriteLine("2. Disegna un quadrato");
            Console.WriteLine("3. Disegna un cerchio");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());

            return scelta;
        }
    }
}