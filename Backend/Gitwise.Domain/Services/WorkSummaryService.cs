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
        
        return "work summary";
    }
    
    private static List<FileChange> GetFirstFileChanges(List<Commit> commits)
    {
        var seenFileNames = new HashSet<string>();
        var firstFileChanges = new List<FileChange>();

        foreach (var commit in commits)
        {
            foreach (var fileChange in commit.FileChanges)
            {
                if (seenFileNames.Add(fileChange.FileName))
                {
                    firstFileChanges.Add(fileChange);
                }
            }
        }

        return firstFileChanges;
    }
}