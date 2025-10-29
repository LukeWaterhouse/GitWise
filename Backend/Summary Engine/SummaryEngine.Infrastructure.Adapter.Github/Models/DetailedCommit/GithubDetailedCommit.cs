using SummaryEngine.Adapter.Github.Models.Commit;
using SummaryEngine.Adapter.Github.Models.File;

namespace SummaryEngine.Adapter.Github.Models.DetailedCommit;

public record GithubDetailedCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubStats Stats,
    string Html_Url,
    List<GithubFileChange> Files);