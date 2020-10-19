using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Esame.Finale.Models;

namespace Vendrame.Esame.Finale.Service
{
    public interface IServiceBiglietto
    {
        void InsertBiglietto(Biglietto r);

        IEnumerable<Biglietto> getBiglietto(string sigla);

        void UpdateBiglietto(int id);
    }
}
