using System;

namespace Esercizio3_Verifica_29042020
{
    class Program
    {
        static void Main(string[] args)
        {
            caricaMatrice();
        }

        static void caricaMatrice()
        {
            int[,] matrice = new int[5,5]; // creazione della matrice
            int numero = 2; //istanzio il numero di partenza

            for(int i=0; i<5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    matrice[i, j] = numero; //inserisco il numero nella posizione corretta
                    numero += 2;    //incremento il numero  
                    Console.Write(matrice[i, j] + "   ");//stampo il numero
                }
                Console.Write("\n");
            }
        }
    }
}
