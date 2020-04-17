using System;
using System.Collections.Generic;
using System.IO;

namespace CS_20200417_Scrubble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci esercizio (1/2): ");
            int scelta = int.Parse(Console.ReadLine());

            if (scelta == 1)
                esercizio1();
            else if (scelta == 2)
                esercizio2();
        }

        private static void esercizio1()
        {
            ScrubbleSolve scrubbleSolve;
            List<String> paroleTrovate = new List<String>();
            String[] lettere;
            int jolly = 0;
            bool[] prova = new bool[7];
            lettere = new String[7];

            for (int i = 0; i < 7; i++)
            {
                Console.Write("Lettera numero " + (i + 1) + ": ");
                lettere[i] = Console.ReadLine();
                if (lettere[i].Equals("*"))
                {
                    jolly++;
                }
                if (lettere[i].Length != 1)
                {
                    Console.WriteLine("INSERISCI UNA SOLA LETTERA!!");
                    i--;
                }
            }

            scrubbleSolve = new ScrubbleSolve(lettere, jolly);
            paroleTrovate = scrubbleSolve.getParole();

            Console.WriteLine("Parole trovate: ");

            foreach (String s in paroleTrovate)
            {
                Console.WriteLine(s);
            }
        }

        public static void esercizio2()
        {
            Console.WriteLine("inserisci parola da trovare: ");
            String parola = Console.ReadLine().ToUpper();
            char[] c = new char[parola.Length + 1];
            for (int i = 0; i < parola.Length; i++)
            {
                c[i] = parola[i];
            }
            c[parola.Length] = '*';
            WordUtilities w = new WordUtilities(c);
            List<string> paroleTrovate = w.readFile();
            foreach (String parolaSimile in paroleTrovate)
            {
                Console.WriteLine(parolaSimile);
            }
        }
    }
}
