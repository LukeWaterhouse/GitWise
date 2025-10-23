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
        
        var firstFileChangeCommits = GetFirstFileChanges(commitsByRepository.Values.SelectMany(c => c).ToList());
        
        Dictionary<string, FileSnapshot> fileNameSnapshots = new();
        
        foreach (var fileChange in firstFileChangeCommits)
        {
            var fileSnapshot = await externalFileSnapshotService.GetFileSnapshotAsync(fileChange.Item2, fileChange.Item1, ct);
            fileNameSnapshots[fileChange.Item1.FileName] = fileSnapshot;
        }
        
        return "work summary";
    }
    
    private static List<(FileChange, Commit)> GetFirstFileChanges(List<Commit> commits)
    {
        var seenFileNames = new HashSet<string>();
        var firstFileChangeCommits = new List<(FileChange, Commit)>();

        foreach (var commit in commits)
        {
            foreach (var fileChange in commit.FileChanges)
            {
                if (seenFileNames.Add(fileChange.FileName))
                {
                    firstFileChangeCommits.Add((fileChange, commit));
                }
            }
        }

        return firstFileChangeCommits;
    }
}