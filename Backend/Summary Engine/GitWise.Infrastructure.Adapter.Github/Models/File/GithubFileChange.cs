namespace GitWise.Adapter.Github.Models.File;

public record GithubFileChange(
    string Sha,
    string Filename,
    int Additions,
    int Deletions,
    int Changes,
    string Patch);