using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_20200422
{
    class Proprietario
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string CittaResidenza { get; set; }
        public int AnnoPatente { get; set; }
        //navigation property che consentono di navigare nella mia struttura dati
        public List<Automobile> ListaAutomobili { get; set; }


    }
}
