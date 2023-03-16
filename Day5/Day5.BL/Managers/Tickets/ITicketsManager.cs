using Day5.BL.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.BL.Managers.Tickets
{
    public interface ITicketsManager
    {
        public List<TicketReadVM> GetAll();
        TicketDetailsVM? GetTicketDetails(int id);
        //PatientEditVM? GetForEdit(int id);
        //void Update(PatientEditVM patientVM);
    }
}
