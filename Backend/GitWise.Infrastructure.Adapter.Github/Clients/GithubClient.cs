using System.Text.Json;
using GitWise.Adapter.Github.Common.Constants;
using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Models.Blob;
using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.DetailedCommit;
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
        var endpoint = string.Format(GithubEndpoints.GetRepositoriesTemplate, organisationName);
        
        var response = await GetGithubResponseAsync<List<GithubRepository>>(endpoint, ct);
        return response;
    }

    public async Task<List<GithubCommit>> GetDailyCommitsAsync(
        string organisationName,
        string repositoryName,
        string authorEmail,
        DateTime date,
        CancellationToken ct)
    {
        var startOfDay = date.Date.ToUniversalTime();
        var endOfDay = startOfDay.AddDays(1);
        
        var queryParams = new Dictionary<string, string?>
        {
            ["author"] = authorEmail,
            ["since"] = startOfDay.ToString("o"),
            ["until"] = endOfDay.ToString("o")
        };
        
        var endpoint = string.Format(GithubEndpoints.GetCommitsTemplate, organisationName, repositoryName);
        var endpointWithQueryParams = QueryHelpers.AddQueryString(endpoint, queryParams);
        
        var response = await GetGithubResponseAsync<List<GithubCommit>>(endpointWithQueryParams, ct);

        return response;
    }

    public async Task<GithubDetailedCommit> GetCommitDetailsAsync(string organisationName, string repositoryName, string commitSha, CancellationToken ct)
    {
        var baseUrl = string.Format(GithubEndpoints.GetCommitByShaTemplate, organisationName, repositoryName, commitSha);
        
        var response = await GetGithubResponseAsync<GithubDetailedCommit>(baseUrl, ct);
        return response;
    }

    public async Task<GithubBlob> GetBlobAsync(string organisationName, string repositoryName, string blobSha, CancellationToken ct)
    {
        var baseUrl = string.Format(GithubEndpoints.GetBlobByShaTemplate, organisationName, repositoryName, blobSha);
        
        var response = await GetGithubResponseAsync<GithubBlob>(baseUrl, ct);
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
