using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TicketSystemDemo.Models;

namespace TicketSystemDemo.Services
{
    public class TicketSystemService
    {
        private TicketSystemContext _context;

        public TicketSystemService(TicketSystemContext ticketSystemContext)
        {
            _context = ticketSystemContext;
        }
        public HttpClient Client { get; }

       
    }
}
