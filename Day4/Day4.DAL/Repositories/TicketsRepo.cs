using Day4.DAL.Context;
using Day4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day4.DAL.Repositories
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly TicketContext _context;

        public TicketsRepo(TicketContext context)
        {
            _context = context;
        }

        public void Add(Ticket ticket)
        {
            _context.Set<Ticket>().Add(ticket);
        }

        public void Delete(int id)
        {
            var ticketToDelete = Get(id);
            if (ticketToDelete != null)
            {
                _context.Set<Ticket>().Remove(ticketToDelete);
            }
        }

        public Ticket? Get(int id)
        {
            return _context.Set<Ticket>().Find(id);
        }

        public IEnumerable<Ticket> GetAll()
        {
           return _context.Set<Ticket>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
           
        }
    }
}
