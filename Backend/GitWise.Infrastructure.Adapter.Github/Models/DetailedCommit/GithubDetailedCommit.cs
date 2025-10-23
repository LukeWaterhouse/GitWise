using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.File;
using GitWise.Adapter.Github.Models.Repository;

namespace GitWise.Adapter.Github.Models.DetailedCommit;

public record GithubDetailedCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubStats Stats,
    string Html_Url,
    List<GithubFileChange> Files);