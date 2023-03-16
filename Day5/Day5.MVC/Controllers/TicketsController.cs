using Day5.BL.Managers.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Day5.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager)
        {
           _ticketsManager = ticketsManager;
        }

        public IActionResult Index()
        {
            return View(_ticketsManager.GetAll());
        }
        public IActionResult Details(int id)
        {
            var ticketVM = _ticketsManager.GetTicketDetails(id);
            if (ticketVM is null)
            {
                return NotFound();
            }

            return View(ticketVM);
        }
    }
}
