using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models
{
    public class User
    {
        [Key]
        public Guid Userkey { get; set; }

        public Guid? UserTypeKey { get; set; }

        public string UserName { get; set; }
    }
}
