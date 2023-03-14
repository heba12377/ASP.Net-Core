using System.ComponentModel.DataAnnotations;
namespace Day3.Models.View;
using Day3.Models.Domain;

public record AddTicketVM
{
    public string Description { get; set; } = string.Empty;
    public Severity Severity { get; set; }
    
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; set; }
   
    [Display(Name = "Department")]
    public Guid DepartmentId { get; init; }

    [Display(Name = "Developers")]
    public List<Guid> DevelopersIds { get; init; } = new();
}

