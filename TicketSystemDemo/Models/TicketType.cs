using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models
{
    public class TicketType
    {
        [Key]
        public Guid TicketTypeKey { get; set; }
        public string TicketTypeName { get; set; }
        public Guid UserTypeKey { get; set; }
        //for  Phase II 
        public bool ReadOnly { get; set; }
        //for  Phase II 
        public bool ResolveOnly { get; set; }

    }
}
