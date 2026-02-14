using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.EfCore;

public class ControlPlaneDbContext(DbContextOptions<ControlPlaneDbContext> options) : DbContext(options)
{
    public DbSet<DbTenant> Tenants { get; set; }
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbDeveloper> Developers { get; set; }
    
    public DbSet<DbWorkSummaryJob> SummaryJobs { get; set; }
    
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

        // Configure SummaryJobs relationships to avoid multiple cascade paths
        modelBuilder.Entity<DbWorkSummaryJob>()
            .HasOne(sj => sj.Tenant)
            .WithMany()
            .HasForeignKey(sj => sj.TenantId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<DbWorkSummaryJob>()
            .HasOne(sj => sj.Developer)
            .WithMany()
            .HasForeignKey(sj => sj.DeveloperId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DbDeveloper>()
            .HasIndex(d => new { d.TenantId, d.Email })
            .IsUnique();
        
        modelBuilder.Entity<DbUser>()
            .HasIndex(u => new { u.TenantId, u.Email })
            .IsUnique();
    }
}