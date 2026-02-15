using SummaryEngine.Adapter.Github.AzureAi.Interfaces;
using SummaryEngine.Adapter.Github.AzureAi.Models.AiPrompts;
using SummaryEngine.Adapter.Github.AzureAi.Models.AiPrompts.Commit;
using SummaryEngine.Domain.Interfaces.External.Ai;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Adapter.Github.AzureAi.Services;

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
                    fileChange.FileSnapshot?.DecodedContent)).ToList()
                )).ToList();

            repositoryAiPromptCommits[repositoryName] = aiPromptCommits;
        }
        
        var workSummaryPrompt = new AiWorkSummaryPrompt(AiQueries.SummarizeCommits, repositoryAiPromptCommits);
        var serializedPrompt = System.Text.Json.JsonSerializer.Serialize(workSummaryPrompt);
        
        if(serializedPrompt.Length > 200000)
        {
            throw new Exception($"The serialized AI prompt exceeds the maximum allowed length ({serializedPrompt.Length}):" + serializedPrompt);
        }
        
        var response = await azureAiClient.GetMessageResponseAsync(serializedPrompt, ct);
        return response;
    }
}