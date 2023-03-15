using Day4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.BL.ViewModels
{
    public record TicketDeleteVM(int Id, string Title, string Description, Severity Severity)
    {

    }
}
