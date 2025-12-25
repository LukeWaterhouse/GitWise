using System.ComponentModel.DataAnnotations;
using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models.Enums;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string AzureObjectId { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public Role Role { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
}
