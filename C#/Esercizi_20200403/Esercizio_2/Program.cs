using System;
using System.IO;

namespace Esercizio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int r=0;
            string testo;
            string path = @"C:\Esercizio\File_esercizio2.txt";
            var file1 = File.Create(path);
             
            file1.Close();

            Console.Write("Inserisci il numero di righe che vuoi scrivere: ");
            r = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Righe =" + r);        

            for(int i = 0 ; i < r ; i++){
                Console.WriteLine("Stai scrivendo sulla " + (i+1) + " riga:");
                testo = Console.ReadLine();
                File.AppendAllText(path,testo);
                File.AppendAllText(path,Environment.NewLine);   
                Console.WriteLine("I = "+ i);         
            }

            Console.WriteLine("Inserisci la riga che vuoi visualizzare: ");
            int riga = int.Parse(Console.ReadLine());

            riga--;

            string[] text = File.ReadAllLines(path);

            Console.WriteLine("Il testo sulla "+ riga + " riga è: " + text[riga]);
        }
    }
}
