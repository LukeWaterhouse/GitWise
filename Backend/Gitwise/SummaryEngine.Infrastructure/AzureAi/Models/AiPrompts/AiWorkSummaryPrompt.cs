using SummaryEngine.Adapter.Github.AzureAi.Models.AiPrompts.Commit;

namespace SummaryEngine.Adapter.Github.AzureAi.Models.AiPrompts;

public record AiWorkSummaryPrompt(
    string Query,
    Dictionary<string, List<AiPromptCommit>> RepositoryCommits);