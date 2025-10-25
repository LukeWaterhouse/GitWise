using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External.Ai;
using Gitwise.Domain.Interfaces.External.Git;
using Gitwise.Domain.Models;

namespace Gitwise.Domain.Services;

public class WorkSummaryService(
    ICommitService commitService,
    IExternalFileSnapshotService externalFileSnapshotService,
    IExternalAiSummaryService externalAiSummaryService) : IWorkSummaryService
{
    public async Task<string> GenerateDailyWorkSummaryAsync(string? organisationName, string authorUsername, DateTime date, CancellationToken ct)
    {
        //TODO: Review parallelism and performance here
        
        var commitsByRepository = await commitService.GetDailyRepoCommitsByUserAsync(organisationName, authorUsername, date, ct);

        var tasks = commitsByRepository.Values.Select(PopulateFirstFileChangeSnapshots).ToList();
        await Task.WhenAll(tasks);
        
        var workSummary = await externalAiSummaryService.GetAiGeneratedSummaryAsync(commitsByRepository, ct);
        
        return workSummary;
    }
    
    private async Task PopulateFirstFileChangeSnapshots(List<Commit> commits)
    {
        var seenFileNames = new HashSet<string>();
        var tasks = new List<Task>();
    
        foreach (var commit in commits)
        {
            foreach (var fileChange in commit.FileChanges)
            {
                if (!seenFileNames.Add(fileChange.FileName)) continue;
    
                var task = Task.Run(async () =>
                {
                    var fileSnapshot = await externalFileSnapshotService.GetFileSnapshotAsync(
                        commit,
                        fileChange,
                        CancellationToken.None);
    
                    fileChange.FileSnapshot = fileSnapshot;
                });
    
                tasks.Add(task);
            }
        }
    
        await Task.WhenAll(tasks);
    }
}