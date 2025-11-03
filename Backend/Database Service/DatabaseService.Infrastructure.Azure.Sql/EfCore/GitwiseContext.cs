using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Infrastructure.Azure.Sql.EfCore;

public class GitwiseContext(DbContextOptions<GitwiseContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<WorkSummary> WorkSummaries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tenant>()
            .HasMany(t => t.Users)
            .WithOne(u => u.Tenant)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tenant>()
            .HasMany(t => t.Developers)
            .WithOne(d => d.Tenant)
            .HasForeignKey(d => d.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Developer>()
            .HasMany(d => d.WorkSummaries)
            .WithOne(ws => ws.Developer)
            .HasForeignKey(ws => ws.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkSummary>()
            .HasIndex(ws => new { ws.DeveloperId, ws.Date })
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => new { u.TenantId, u.Email })
            .IsUnique();
    }
}