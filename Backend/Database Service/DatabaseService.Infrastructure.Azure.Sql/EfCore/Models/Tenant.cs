using System.ComponentModel.DataAnnotations;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

public class Tenant
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public string Name { get; init; }
    
    public ICollection<User> Users { get; init; }
    public ICollection<Developer> Developers { get; init; }
}