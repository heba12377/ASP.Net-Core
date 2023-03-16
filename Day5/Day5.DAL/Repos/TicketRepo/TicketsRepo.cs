using Day5.DAL.Context;
using Day5.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.DAL.Repos.TicketRepo
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly MyContext _context;

        public TicketsRepo(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>();
        }
        public Ticket? GetTickettWithDevelperAndDepartment(int id)
        {
            return _context.Set<Ticket>()
                .Include(t => t.Department)
                .Include(t => t.Developers)
                .FirstOrDefault(t => t.Id == id);
        }

        public Ticket? GetTicketWithDevelopers(int id)
        {
            return _context.Set<Ticket>()
                .Include(t => t.Developers)
                .FirstOrDefault(t => t.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            
        }
    }
}
