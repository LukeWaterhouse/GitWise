namespace GitWise.Adapter.Github.Common.Constants;

public static class GithubEndpoints
{
    
    public const string GetCommits = "/repos/{0}/{1}/commits";
    public const string GetCommitBySha = "/repos/{0}/{1}/commits/{2}";
}
