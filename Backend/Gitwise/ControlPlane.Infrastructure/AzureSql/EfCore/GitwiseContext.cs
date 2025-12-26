using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.EfCore;

public class GitwiseContext(DbContextOptions<GitwiseContext> options) : DbContext(options)
{
    public DbSet<DbTenant> Tenants { get; set; }
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbDeveloper> Developers { get; set; }
    
    public DbSet<DbSummaryJob> SummaryJobs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DbTenant>()
            .HasMany(t => t.Users)
            .WithOne(u => u.DbTenant)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DbTenant>()
            .HasMany(t => t.Developers)
            .WithOne(d => d.DbTenant)
            .HasForeignKey(d => d.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DbDeveloper>()
            .HasIndex(d => new { d.TenantId, d.Email })
            .IsUnique();
        
        modelBuilder.Entity<DbUser>()
            .HasIndex(u => new { u.TenantId, u.Email })
            .IsUnique();
    }
}