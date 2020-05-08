using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Esercizio2_Verifica_29042020
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Alessandro Vendrame\Desktop\Anagrafica.txt";
            var pathsalvataggio = @"C:\Users\Alessandro Vendrame\Desktop\ETICHETTE.txt";

            File.WriteAllText(pathsalvataggio, ""); //svuoto o creo il file

            using (StreamReader sr = new StreamReader(path))
            {
                string riga = "";
                while ((riga = sr.ReadLine()) != null) //controllo che il file non sia finito
                {
                     string[] splittato = riga.Split(";");
                     for (int i = 0; i < splittato.Length; ++i)
                     {
                        Regex regex = new Regex("^(Sig. |Sig.ra |Indirizzo:|Citta:|CAP:)"); //faccio il regex
                        string match = regex.Replace(splittato[i],string.Empty);

                        Console.WriteLine(match); //stampo la stringa modificata
                        File.AppendAllText(pathsalvataggio, match + Environment.NewLine); //scrivo sul file di testo
                     }

                    Console.Write("\n");
                }
            }
        }

        private static string[] splitfile(string text)
        {
            return text.Split(";");
        }
    }
}
