using Day4.BL;
using Day4.BL.ViewModels;
using Day4.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4.MVC.Controllers
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
            var ticket = _ticketsManager.Get(id);
            if (ticket is null)
            {
                View("NotFound");
            }
            return View(ticket);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(TicketAddVM ticketvm)
        {
            _ticketsManager.Add(ticketvm);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _ticketsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
