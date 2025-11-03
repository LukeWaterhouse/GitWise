using System.ComponentModel.DataAnnotations;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

public class Developer
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }

    public ICollection<WorkSummary> WorkSummaries { get; set; }
}
