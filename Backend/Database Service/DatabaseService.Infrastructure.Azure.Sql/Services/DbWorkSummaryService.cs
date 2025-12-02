using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.Exceptions;
using DatabaseService.Infrastructure.Azure.Sql.Exceptions.Enums;
using DatabaseService.Infrastructure.Azure.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Infrastructure.Azure.Sql.Services;

public class DbWorkSummaryService(
    IDbContextFactory<GitwiseContext> dbContextFactory, 
    IDbDeveloperService developerService) : IDbWorkSummaryService
{
    public async Task CreateWorkSummaryAsync(
        string developerEmail, 
        string developerName, 
        string tenantName, 
        DateOnly date, 
        string workSummary)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        
        var developerExists = await context.Developers
            .AnyAsync(d => d.Email == developerEmail);

        if (!developerExists)
        {
            await developerService.CreateDeveloperAsync(developerName, developerEmail, tenantName);
        }
        
        var developer = await context.Developers
            .FirstOrDefaultAsync(d => d.Email == developerEmail);

        if (developer is null)
        {
            throw new RecordNotFoundException(RecordType.Developer, developerName);
        }
        
        var workSummaryExists = await context.WorkSummaries
            .AnyAsync(ws => ws.DeveloperId == developer.Id && ws.Date == date);

        if (workSummaryExists)
        {
            throw new DuplicateRecordException(RecordType.WorkSummary, $"{developerEmail} - {date}");
        }
        
        var workSummaryEntity = new EfCore.Models.WorkSummary
        {
            DeveloperId = developer.Id,
            Developer = developer,
            Date = date,
            Summary = workSummary
        };
        
        context.WorkSummaries.Add(workSummaryEntity);
        await context.SaveChangesAsync();
    }
}