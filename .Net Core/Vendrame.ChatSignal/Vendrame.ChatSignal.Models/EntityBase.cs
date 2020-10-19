using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public abstract class EntityBase<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
