using Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

namespace Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts;

public record AiWorkSummaryPrompt(
    string Query,
    Dictionary<string, List<AiPromptCommit>> RepositoryCommits);