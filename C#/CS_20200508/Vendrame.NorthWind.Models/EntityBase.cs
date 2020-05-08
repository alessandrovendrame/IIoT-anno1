using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.NorthWind.Models
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }
}
