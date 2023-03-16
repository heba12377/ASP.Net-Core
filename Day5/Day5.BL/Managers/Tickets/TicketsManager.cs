using Day5.BL.ViewModels.Ticket;
using Day5.DAL.Repos.TicketRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day5.DAL.Models;

namespace Day5.BL.Managers.Tickets
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }
        public List<TicketReadVM> GetAll()
        {
            var ticketsFromDB = _ticketsRepo.GetAll();
            return ticketsFromDB.Select(t => new TicketReadVM(t.Id, t.Description))
                .ToList();
        }

        public TicketDetailsVM? GetTicketDetails(int id)
        {
           Ticket? ticketFromDb = _ticketsRepo.GetTickettWithDevelperAndDepartment(id);
            
            if(ticketFromDb == null) return null;

            return new TicketDetailsVM(
                Id: ticketFromDb!.Id,
                Description: ticketFromDb.Description,
                DeptName: ticketFromDb.Department?.Name ?? "",
                DevelperCount: ticketFromDb.Developers.Count);
        }
    }
}
