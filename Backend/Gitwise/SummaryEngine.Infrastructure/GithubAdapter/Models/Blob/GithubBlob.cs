namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.Blob;

public record GithubBlob(
    string Sha,
    int Size,
    string Content,
    string Encoding);