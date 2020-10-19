using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.Esame.Finale.Models
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }

    }

    public abstract class EntityBase : EntityBase<int>
    {

    }
}
