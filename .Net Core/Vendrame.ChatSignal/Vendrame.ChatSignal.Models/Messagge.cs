using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class Messagge : EntityBase<int>
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
