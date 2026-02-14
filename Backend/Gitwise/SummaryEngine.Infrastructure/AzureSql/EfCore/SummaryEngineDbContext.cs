using Microsoft.EntityFrameworkCore;
using SummaryEngine.Adapter.Github.AzureSql.EfCore.Models;

namespace SummaryEngine.Adapter.Github.AzureSql.EfCore;

public class SummaryEngineDbContext(DbContextOptions<SummaryEngineDbContext> options) : DbContext(options)
{
    public DbSet<DbWorkSummary> WorkSummaries { get; set; } = null!;
}