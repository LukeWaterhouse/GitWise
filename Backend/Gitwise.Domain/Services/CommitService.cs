using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models.Commit;

namespace Gitwise.Domain.Services;

public class CommitService(IExternalCommitService externalCommitService, IExternalRepositoryService externalRepositoryService) : ICommitService
{
    public async Task<Dictionary<string, List<Commit>>> GetAllRepoCommitsAsync(
        string organisationName, 
        string authorEmail,
        DateTime date, 
        CancellationToken ct)
    {
        var organisationRepositories = await externalRepositoryService.GetAllOrganisationRepositoriesAsync(organisationName, ct);
        
        var commitsByRepository = new Dictionary<string, List<Commit>>();
        
        foreach (var repository in organisationRepositories)
        {
            var commits = await externalCommitService.GetCommitsAsync(organisationName, repository, authorEmail, date, ct);
            commitsByRepository[repository.Name] = commits;
        }
        
        return commitsByRepository;
    }
}