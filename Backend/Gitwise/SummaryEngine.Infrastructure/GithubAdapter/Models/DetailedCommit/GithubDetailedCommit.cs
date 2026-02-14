using SummaryEngine.Adapter.Github.GithubAdapter.Models.Commit;
using SummaryEngine.Adapter.Github.GithubAdapter.Models.File;

namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.DetailedCommit;

public record GithubDetailedCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubStats Stats,
    string Html_Url,
    List<GithubFileChange> Files);