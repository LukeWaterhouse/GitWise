using System.ComponentModel.DataAnnotations;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class DbUser
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string AzureObjectId { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public DbRole DbRole { get; set; }

    public Guid TenantId { get; set; }
    public DbTenant DbTenant { get; set; }
}
