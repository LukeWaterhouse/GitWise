namespace GitWise.Adapter.Github.Common.Constants;

public static class GithubEndpoints
{
    public const string GetRepositoriesTemplate = "/users/{0}/repos";
    public const string GetCommitsTemplate = "/repos/{0}/{1}/commits";
    public const string GetCommitByShaTemplate = "/repos/{0}/{1}/commits/{2}";
}
