using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.ApiBoredWorkService.Model
{
    public class Activity : EntityBase<int>
    {
        //public int Id { get; set; }
        public String ActivityType { get; set; }
        public String Type { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
