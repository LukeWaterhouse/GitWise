using System.ComponentModel.DataAnnotations;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class DbDeveloper
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }

    public Guid TenantId { get; set; }
    public DbTenant DbTenant { get; set; }

}
