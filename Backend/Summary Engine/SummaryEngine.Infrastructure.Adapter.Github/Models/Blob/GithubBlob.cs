namespace SummaryEngine.Adapter.Github.Models.Blob;

public record GithubBlob(
    string Sha,
    int Size,
    string Content,
    string Encoding);