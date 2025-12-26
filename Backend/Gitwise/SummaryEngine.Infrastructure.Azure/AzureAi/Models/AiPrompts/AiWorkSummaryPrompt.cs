using SummaryEngine.Infrastructure.Azure.AzureAi.Models.AiPrompts.Commit;

namespace SummaryEngine.Infrastructure.Azure.AzureAi.Models.AiPrompts;

public record AiWorkSummaryPrompt(
    string Query,
    Dictionary<string, List<AiPromptCommit>> RepositoryCommits);