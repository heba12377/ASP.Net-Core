using Day4.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.BL
{
    public interface ITicketsManager
    {
        List<TicketReadVM> GetAll();
        TicketReadVM? Get(int id);
        void Add(TicketAddVM ticketVM);
        void Delete(int Id);
    }
}
