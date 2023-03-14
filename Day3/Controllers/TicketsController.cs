using Microsoft.AspNetCore.Mvc;
using Day3.Models.Domain;
using Day3.Models.View;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Day3.Controllers
{
    public class TicketsController : Controller
    {
     
        public IActionResult Index()
        {
            var tickets = Ticket.GetTickets();
            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var departments = Department.GetDepartments();
            var countriesList = departments.Select(dept => new SelectListItem(dept.Name, dept.Id.ToString()));
            ViewData["departments"] = countriesList;

            var developers = Developer.GetDevelopers();
            var developersListItems = developers.Select(a => new SelectListItem(a.FirstName , a.Id.ToString()));
            ViewBag.developersListItems = developersListItems;

            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(AddTicketVM ticketvm)
        {

            var ticketsList = Ticket.GetTickets();
            var developers = Developer.GetDevelopers();
            var selectedTicketsIds = ticketvm.DevelopersIds;

            var selectedDevelopers = developers
                .Where(a => selectedTicketsIds.Contains(a.Id))
                .ToList();


            Ticket ticket = new  Ticket
            {
                Id = new Guid(),
                Description = ticketvm.Description,
                IsClosed = ticketvm.IsClosed,
                Severity = ticketvm.Severity,
                Department = Department.GetDepartments().First(c => c.Id == ticketvm.DepartmentId),
                Developers = selectedDevelopers
            };
            ticketsList.Add(ticket);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var ticketsList = Ticket.GetTickets();
            var ticketToDelete = ticketsList.First(a => a.Id == id);
            ticketsList.Remove(ticketToDelete);
           
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var departments = Department.GetDepartments();
            var countriesList = departments.Select(dept => new SelectListItem(dept.Name, dept.Id.ToString()));
            ViewData["departments"] = countriesList;

            var developers = Developer.GetDevelopers();
            var developersListItems = developers.Select(a => new SelectListItem(a.FirstName, a.Id.ToString()));
            ViewBag.developersListItems = developersListItems;

            var ticketsList = Ticket.GetTickets();
            var ticketToEdit = ticketsList.First(a => a.Id == id);
            var ticketVM = new EditTicketVM
            {
                     Id = ticketToEdit.Id,
                     Description = ticketToEdit.Description,
                     IsClosed = ticketToEdit.IsClosed,
                     Severity = ticketToEdit.Severity,
                     DepartmentId = ticketToEdit.Department.Id,
                     DevelopersIds  = ticketToEdit.Developers.Select(d => d.Id).ToList(),
            };

            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            var ticketsList = Ticket.GetTickets();
            var selectedDevelopers = GetawDevelopersByIds(ticketVM.DevelopersIds);

            var ticketToEdit = ticketsList.First(t => t.Id == ticketVM.Id);

            ticketToEdit.Description = ticketVM.Description;
            ticketToEdit.IsClosed = ticketVM.IsClosed;
            ticketToEdit.Severity = ticketVM.Severity;
            ticketToEdit.Department = Department.GetDepartments().First(c => c.Id == ticketVM.DepartmentId);
            ticketToEdit.Developers = selectedDevelopers;

            return RedirectToAction(nameof(Index));
        }
        private static List<Developer> GetawDevelopersByIds(List<Guid> selectedDeveloperIds)
        {
            var developers = Developer.GetDevelopers();
            var selectedDevelopers = developers
                .Where(a => selectedDeveloperIds.Contains(a.Id))
                .ToList();
            return selectedDevelopers;
        }
    }
}
