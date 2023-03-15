using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4.BL.ViewModels;
using Day4.DAL.Models;
using Day4.DAL.Repositories;

namespace Day4.BL
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }

        public void Add(TicketAddVM ticketVM)
        {
            var ticket = new Ticket
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Severity = ticketVM.Severity
            };

            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();
        }

        public TicketReadVM? Get(int id)
        {
            var ticketsFromDB = _ticketsRepo.Get(id);
            if (ticketsFromDB == null)
            {
                return null;
            }
            return new TicketReadVM(ticketsFromDB.Id, ticketsFromDB.Title, ticketsFromDB.Description, ticketsFromDB.Severity);
        }

        public List<TicketReadVM> GetAll()
        {
            var ticketsFromDB = _ticketsRepo.GetAll();
            return ticketsFromDB.Select(t => new TicketReadVM(t.Id, t.Title, t.Description, t.Severity))
                .ToList();
        }

        void ITicketsManager.Delete(int Id)
        {
            _ticketsRepo.Delete(Id);
            _ticketsRepo.SaveChanges();
 ;      }
    }
}
