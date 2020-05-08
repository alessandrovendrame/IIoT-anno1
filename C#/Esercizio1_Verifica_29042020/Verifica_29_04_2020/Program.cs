using System;

namespace Verifica_29_04_2020
{
    class Program
    {
        static void Main(string[] args)
        {

            int puntifreccia=0;
            int punteggio=0;
            for(int i=0;i<3; i++)
            {
                //assegnazione dei punti randomici
                puntifreccia = scocca();

                Console.WriteLine("Punteggio freccia #" + (i + 1) + ": " + puntifreccia);

                //somma al punteggio totale
                punteggio += puntifreccia;
            }
            //stampa del punteggio totale
            Console.WriteLine("Punteggio totale ottenuto : " + punteggio);
        }

        private static int scocca()
        {
            int punti=0;
            Random rnd = new Random();
            //creazione dei randomici
            double x = rnd.Next(-40,40);
            double y = rnd.Next(-40,40);
            //calcolo della distanza
            double distanza = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            //assegnazione punteggio
            if(distanza >= 0 && distanza < 10)
            {
                punti = 10;
            }else if(distanza>=10 && distanza < 20)
            {
                punti = 5;
            }else if(distanza >=20 && distanza < 40)
            {
                punti = 1;
            }

            return punti;
        }
    }
}
