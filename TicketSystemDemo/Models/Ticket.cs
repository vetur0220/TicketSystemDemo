using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models
{
    public class Ticket
    {
        [Key]
        public Guid TicketKey { get; set; }

        public Guid TicketTypeKey { get; set; }
        public String TicketName { get; set; }
        public String Summary { get; set; }
        public String Description { get; set; }
        public bool IsResolve { get; set; }

        /// <summary>
        /// Phase II
        /// </summary>
        public int Severity { get; set; }
        /// <summary>
        /// Phase II
        /// </summary>
        public int Priority { get; set; }
    }
}
