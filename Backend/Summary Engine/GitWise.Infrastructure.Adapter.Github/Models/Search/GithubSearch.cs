namespace GitWise.Adapter.Github.Models.Search;

public class GithubSearch<T>
{
    public int TotalCount { get; init; }
    public bool IncompleteResults { get; init; }
    public List<T> Items { get; init; } = new();
}