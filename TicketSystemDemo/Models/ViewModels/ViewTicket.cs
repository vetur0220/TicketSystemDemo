using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models.ViewModels
{
    public class ViewTicket : Ticket
    {
        public string UserName { get; set; }
        public string TicketTypeName { get; set; }

        public string OnlyRead { get; set; }

        public bool ResolveOnly { get; set; }
        public bool ReadOnly { get; set; }
    }
}
