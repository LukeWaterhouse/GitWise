using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace Gitwise.Domain.Services;

public class CommitService(IExternalCommitService externalCommitService, IExternalRepositoryService externalRepositoryService) : ICommitService
{
    public async Task<Dictionary<string, List<Commit>>> GetAllRepoCommitsAsync(
        string organisationName, 
        string userEmail,
        DateTime date, 
        CancellationToken ct)
    {
        var organisationRepositories = await externalRepositoryService.GetAllOrganisationRepositoriesAsync(organisationName, ct);
        
        var commitsByRepository = new Dictionary<string, List<Commit>>();
        
        foreach (var repository in organisationRepositories)
        {
            var commits = await externalCommitService.GetDailyCommitsAsync(organisationName, repository, userEmail, date, ct);
            commitsByRepository[repository.Name] = commits;
        }
        
        var filteredCommits = 
            commitsByRepository.Where(x => x.Value.Any())
            .ToDictionary(x => x.Key, x => x.Value);
        
        return filteredCommits;
    }
}