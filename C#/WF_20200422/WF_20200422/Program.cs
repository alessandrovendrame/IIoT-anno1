using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_20200422
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            dbProprietari g = new dbProprietari();
            List<Proprietario> elencoProprietari = g.RecuperaTutti();

            foreach(Proprietario p in elencoProprietari)
            {
                
                Console.WriteLine(p.CodiceFiscale + " " + p.Nome + " " + p.CittaResidenza + " " + p.AnnoPatente);
                Console.WriteLine("Possiede le seguenti automobili: ");

                foreach(Automobile b in p.ListaAutomobili)
                {
                    Console.WriteLine(b.Targa + " " + b.Modello + " " + b.Cilindrata);
                }
                Console.WriteLine();
            }

            var a = new Proprietario();
            a.CodiceFiscale = "123456789";
            a.CittaResidenza = "Roma";
            a.Nome = "Paolo";
            a.AnnoPatente = 2020;

            g.Aggiungi(a);

            Console.ReadLine();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
