using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.Esame.Finale.Models
{
    public class Biglietto : EntityBase<int>
    {
        public string SectionCode { get; set; }
        public int IndexCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ServingDate { get; set; }
    }
}
