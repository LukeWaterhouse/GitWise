using SummaryEngine.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

namespace SummaryEngine.Infrastructure.Ai.Azure.Models.AiPrompts;

public record AiWorkSummaryPrompt(
    string Query,
    Dictionary<string, List<AiPromptCommit>> RepositoryCommits);