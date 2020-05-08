using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.Earthquake.Models
{
    public abstract class EntityBase<T>
    {
        public T id { get; set; }
    }
}
