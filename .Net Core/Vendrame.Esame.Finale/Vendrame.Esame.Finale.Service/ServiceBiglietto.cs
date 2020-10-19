using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Esame.Finale.Data;
using Vendrame.Esame.Finale.Models;

namespace Vendrame.Esame.Finale.Service
{
    public class ServiceBiglietto : IServiceBiglietto
    {
        private readonly IBigliettoData _bigliettoData;

        public ServiceBiglietto(IBigliettoData bigliettoData)
        {
            _bigliettoData = bigliettoData;
        }
        public IEnumerable<Biglietto> getBiglietto(string sigla)
        {
            return _bigliettoData.GetAll(sigla);
        }

        public void InsertBiglietto(Biglietto r)
        {
            _bigliettoData.Insert(r);
        }

        public void UpdateBiglietto(int id)
        {
            _bigliettoData.Update(id);
        }
    }
}
