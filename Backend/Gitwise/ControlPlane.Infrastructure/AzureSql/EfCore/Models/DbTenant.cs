using System.ComponentModel.DataAnnotations;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class DbTenant
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public string Name { get; init; }
    
    public ICollection<DbUser> Users { get; init; }
    public ICollection<DbDeveloper> Developers { get; init; }
}