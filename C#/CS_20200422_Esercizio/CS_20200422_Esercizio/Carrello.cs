using System;
using System.Collections.Generic;
using System.Text;

namespace CS_20200422_Esercizio
{
    class Carrello<TObject>
    {
        private List<ObjectCarrello> container = new List<ObjectCarrello>();

        public void addItem(ObjectCarrello oggetto)
        {
            container.Add(oggetto);
        }
    }
}
