using Gitwise.Domain.Interfaces.External.Ai;
using Gitwise.Domain.Models;
using Gitwise.Infrastructure.Ai.Azure.Interfaces;
using Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts;
using Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

namespace Gitwise.Infrastructure.Ai.Azure.Services;

public class AzureAiSummaryService(IAzureAiClient azureAiClient) : IExternalAiSummaryService
{
    public async Task<string> GetAiGeneratedSummaryAsync(Dictionary<string, List<Commit>> repositoryCommits, CancellationToken ct)
    {
        
        var repositoryAiPromptCommits = new Dictionary<string, List<AiPromptCommit>>();
        
        foreach (var (repositoryName, commits) in repositoryCommits)
        {
            var aiPromptCommits = commits.Select(commit => new AiPromptCommit(
                commit.Message,
                new AiPromptChangeStats(
                    commit.TotalChanges.Total,
                    commit.TotalChanges.Additions,
                    commit.TotalChanges.Deletions),
                commit.FileChanges.Select(fileChange => new AiPromptFileChange(
                    fileChange.FileName,
                    new AiPromptChangeStats(
                        commit.TotalChanges.Total,
                        commit.TotalChanges.Additions,
                        commit.TotalChanges.Deletions),
                    fileChange.ChangeDefinition,
                    GetDecodedContent(fileChange.FileSnapshot))).ToList()
                )).ToList();

            repositoryAiPromptCommits[repositoryName] = aiPromptCommits;
        }
        
        var workSummaryPrompt = new AiWorkSummaryPrompt(AiQueries.SummarizeCommit, repositoryAiPromptCommits);
        
        var serializedPrompt = System.Text.Json.JsonSerializer.Serialize(workSummaryPrompt);

        
        var response = await azureAiClient.GetMessageResponseAsync(serializedPrompt, ct);
        return response;
    }
    
    private string? GetDecodedContent(FileSnapshot? fileSnapshot)
    {
        if (fileSnapshot == null || fileSnapshot.Size > 4000)
        {
            return null;
        }
        
        var base64EncodedBytes = Convert.FromBase64String(fileSnapshot.EncodedContent);
        
        
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}