using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemDemo.Models;

namespace TicketSystemDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TicketSystemContext _context;
        public HomeController(ILogger<HomeController> logger, TicketSystemContext ticketSystemContext)
        {
            _logger = logger;
            _context = ticketSystemContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ticket(Guid? TicketKey)
        {
            var data = _context.Ticket.Where(e => e.TicketKey == TicketKey).FirstOrDefault();
            ViewData["data"] = data;
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
