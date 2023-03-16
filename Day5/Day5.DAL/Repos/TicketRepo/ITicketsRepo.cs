using Day5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.DAL.Repos.TicketRepo
{
    public interface ITicketsRepo
    {
        public IEnumerable<Ticket> GetAll();
        Ticket? GetTickettWithDevelperAndDepartment(int id);
        Ticket? GetTicketWithDevelopers(int id);
        void Save();
        void Update(Ticket ticket);
    }
}
