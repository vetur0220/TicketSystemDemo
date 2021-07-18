using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models
{
    public class UserType
    {
        [Key]
        public Guid UserTypeKey { get; set; }

        public string UserTypeName { get; set; }
    }
}
