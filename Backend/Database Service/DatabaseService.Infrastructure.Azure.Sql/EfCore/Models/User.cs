using System.ComponentModel.DataAnnotations;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string AzureObjectId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
}
