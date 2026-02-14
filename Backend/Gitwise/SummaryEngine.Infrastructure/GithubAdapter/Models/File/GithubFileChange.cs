namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.File;

public record GithubFileChange(
    string Sha,
    string Filename,
    int Additions,
    int Deletions,
    int Changes,
    string Patch);