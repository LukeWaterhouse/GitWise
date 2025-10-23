using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace Gitwise.Domain.Services;

public class WorkSummaryService(
    ICommitService commitService,
    IExternalFileSnapshotService externalFileSnapshotService) : IWorkSummaryService
{
    public async Task<string> GenerateDailyWorkSummaryAsync(string organisationName, string userEmail, DateTime date, CancellationToken ct)
    {
        var commitsByRepository = await commitService.GetDailyRepoCommitsByUserAsync(organisationName, userEmail, date, ct);

        var tasks = commitsByRepository.Values.Select(PopulateFirstFileChanges).ToList();
        await Task.WhenAll(tasks);
        
        return "work summary";
    }
    
    private async Task PopulateFirstFileChanges(List<Commit> commits)
    {
        var seenFileNames = new HashSet<string>();

        foreach (var commit in commits)
        {
            foreach (var fileChange in commit.FileChanges)
            {
                if (!seenFileNames.Add(fileChange.FileName)) continue;
                
                var fileSnapshot = await externalFileSnapshotService.GetFileSnapshotAsync(
                    commit,
                    fileChange ,
                    CancellationToken.None);
                    
                fileChange.FileSnapshot = fileSnapshot;
            }
        }
    }
}