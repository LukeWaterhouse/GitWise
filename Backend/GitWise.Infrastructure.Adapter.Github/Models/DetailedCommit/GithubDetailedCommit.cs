using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.File;

namespace GitWise.Adapter.Github.Models.DetailedCommit;

public record GithubDetailedCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubStats Stats,
    string Html_Url,
    List<GithubFileChange> Files) : GithubCommit(Sha, NodeId, Commit, Html_Url);