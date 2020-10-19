using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class User : EntityBase<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int RoomId { get; set; }
    }
}
