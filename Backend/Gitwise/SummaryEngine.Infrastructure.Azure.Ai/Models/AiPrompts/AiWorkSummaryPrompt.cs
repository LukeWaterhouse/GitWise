using SummaryEngine.Infrastructure.Azure.Ai.Models.AiPrompts.Commit;

namespace SummaryEngine.Infrastructure.Azure.Ai.Models.AiPrompts;

public record AiWorkSummaryPrompt(
    string Query,
    Dictionary<string, List<AiPromptCommit>> RepositoryCommits);