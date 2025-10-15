using System.Text.Json;
using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.Repository;
using Microsoft.AspNetCore.WebUtilities;

namespace GitWise.Adapter.Github.Clients;

public class GithubClient(HttpClient httpClient) : IGithubClient
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public async Task<List<GithubRepository>> GetOrganisationReposAsync(string organisationName, CancellationToken ct)
    {
        var response = await GetGithubResponseAsync<List<GithubRepository>>($"orgs/{organisationName}/repos", ct);
        return response;
    }

    public async Task<List<GithubCommit>> GetRepositoryCommitsAsync(
        string organisationName, 
        string repositoryName, 
        string authorEmail, 
        DateTime since,
        DateTime until, 
        CancellationToken ct)
    {
        var baseUrl = $"repos/{organisationName}/{repositoryName}/commits";
        var queryParams = new Dictionary<string, string?>
        {
            ["author"] = authorEmail,
            ["since"] = since.ToString("o"),
            ["until"] = until.ToString("o")
        };

        var url = QueryHelpers.AddQueryString(baseUrl, queryParams);
        var response = await GetGithubResponseAsync<List<GithubCommit>>(url, ct);

        return response;
    }
    
    private async Task<T> GetGithubResponseAsync<T>(string endpoint, CancellationToken ct)
    {
        var response = await httpClient.GetAsync(endpoint, ct);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(ct);

        try
        {
            return JsonSerializer.Deserialize<T>(content, _jsonOptions) ?? throw new InvalidOperationException(
                $"Deserialized null from endpoint: {endpoint}");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                $"Failed to deserialize response from endpoint: {endpoint}", ex);
        }
    }
}
