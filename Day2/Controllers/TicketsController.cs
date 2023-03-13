using Day2.Models.Domian;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var tickets = Ticket.GetTicketsList();
            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            var ticketsList = Ticket.GetTicketsList();
            var ticketToAdd = new Ticket
            {
                CreatedDate = ticket.CreatedDate,
                IsClosed = ticket.IsClosed,
                Description = ticket.Description,
                _Severity = ticket._Severity,
            };
            ticketsList.Add(ticketToAdd);
            return RedirectToAction(nameof(Index));
        }
    }
}
