using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio4_Verifica_29042020
{
    //Creazione della classe Ordine
    class Ordine
    {
        //Dichiarazione di tutti i prop con i get e i set automatici
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public DateTime DataSpedizione { get; set; }
        public string StatoOrdine { get; set; }
        public string Prodotto { get; set; }
        public int QuantitaOrdinata { get; set; }
        public int Prezzo { get; set; }
        public int IdCliente { get; set; }

    }
}
