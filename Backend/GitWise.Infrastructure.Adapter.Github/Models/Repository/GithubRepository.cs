namespace GitWise.Adapter.Github.Models.Repository;

public record GithubRepository(
    string Name,
    string Full_Name,
    string Html_Url,
    bool Private,
    string Description);