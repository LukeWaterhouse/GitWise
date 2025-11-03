using System.ComponentModel.DataAnnotations;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

public class WorkSummary
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid DeveloperId { get; set; }
    public Developer Developer { get; set; }
    public DateOnly Date { get; set; }
    
    [Required]
    public string Summary { get; set; }
}