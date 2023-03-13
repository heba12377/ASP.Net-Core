namespace Day2.Models.Domian;
using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; set; }
        public string Description { get; set; }

        [Display(Name = "Severity")]
         public Severity _Severity { get; set; }

        public Ticket() { }

        public Ticket( DateTime _dateTime, bool _IsClosed, string desc, Severity severity) 
        {
            CreatedDate = _dateTime;
            IsClosed = _IsClosed;
            Description = desc;
            _Severity = severity;
        }
        private static readonly List<Ticket> _tickets = new()
        {
            new Ticket(DateTime.Now, true, " ticket is good",Severity.high),
            new Ticket(DateTime.Now, true, " ticket is baad",Severity.low),
            new Ticket(DateTime.Now, true, " goooooooooood",Severity.medium),
            new Ticket(DateTime.Now, true, " badddddddddd",Severity.high),
            new Ticket(DateTime.Now, true, " ticket is good",Severity.high),
            new Ticket(DateTime.Now, true, " ticket is baad",Severity.low),
            new Ticket(DateTime.Now, true, " goooooooooood",Severity.medium),
            new Ticket(DateTime.Now, true, " badddddddddd",Severity.high),
            new Ticket(DateTime.Now, true, " ticket is good",Severity.high),
            new Ticket(DateTime.Now, true, " ticket is baad",Severity.low),
            new Ticket(DateTime.Now, true, " goooooooooood",Severity.medium),
            new Ticket(DateTime.Now, true, " badddddddddd",Severity.high)
        };
        public static List<Ticket> GetTicketsList() => _tickets;
    
    }

