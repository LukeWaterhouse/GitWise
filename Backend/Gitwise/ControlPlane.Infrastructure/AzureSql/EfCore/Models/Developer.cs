using System.ComponentModel.DataAnnotations;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class Developer
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }

}
