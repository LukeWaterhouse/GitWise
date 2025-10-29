using System.Text.Json;
using SummaryEngine.Adapter.Github.Common.Constants;
using SummaryEngine.Adapter.Github.Interfaces;
using SummaryEngine.Adapter.Github.Models.Blob;
using SummaryEngine.Adapter.Github.Models.Commit;
using SummaryEngine.Adapter.Github.Models.DetailedCommit;
using SummaryEngine.Adapter.Github.Models.Organisation;
using SummaryEngine.Adapter.Github.Models.Repository;
using SummaryEngine.Adapter.Github.Models.Search;

namespace SummaryEngine.Adapter.Github.Clients;

public class GithubClient(HttpClient httpClient) : IGithubClient
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public Task<GithubOrganisation> GetOrganisationAsync(string organisationName, CancellationToken ct)
    {
        var endpoint = string.Format(GithubEndpoints.GetOrganisationTemplate, organisationName);
        
        var response = GetGithubResponseAsync<GithubOrganisation>(endpoint, ct);
        return response;
    }

    public async Task<List<GithubRepository>> GetOrganisationReposAsync(string organisationName, CancellationToken ct)
    {
        var endpoint = string.Format(GithubEndpoints.GetRepositoriesTemplate, organisationName);
        
        var response = await GetGithubResponseAsync<List<GithubRepository>>(endpoint, ct);
        return response;
    }

    public async Task<List<GithubCommit>> GetDailyCommitsAsync(
        string organisationName,
        string authorUsername,
        DateTime date,
        CancellationToken ct)
    {
        var dateString = date.ToString("yyyy-MM-dd");
        var query = $"author:{authorUsername}+org:{organisationName}+committer-date:{dateString}";
        var endpoint = $"/search/commits?q={query}";
        
        var response = await GetGithubResponseAsync<GithubSearch<GithubCommit>>(endpoint, ct);

        return response.Items;
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

    private async Task<T> GetGithubResponseAsync<T>(string endpoint, CancellationToken ct, bool useSpecialSearchHeader = false)
    {
        HttpResponseMessage response;

        if (useSpecialSearchHeader)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.cloak-preview+json"));
            
            response = await httpClient.SendAsync(request, ct);
        }
        else
        {
            response = await httpClient.GetAsync(endpoint, ct);
        }

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
