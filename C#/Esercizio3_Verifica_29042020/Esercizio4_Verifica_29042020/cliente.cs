using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio4_Verifica_29042020
{
    //Creazione della classe Ordine
    class Cliente
    {
        //Dichiarazione di tutti i prop con i get e i set automatici
        public int IdCliente { get; set; }
        public string RagioneSociale { get; set; }
        public string Telefono { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Email { get; set; }
    }
}
