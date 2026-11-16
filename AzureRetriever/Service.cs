using AzureRetriever.Classes;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AzureRetriever
{
    public class Service
    {
        private readonly HttpClient _httpClient;
        private string _urlBase;
        private string _urlApiSpec = "api-version=6.0";
        private string _urlProject = "_apis/projects";
        private string _urlRepo = "/_apis/git/repositories/";

        public Service(HttpClient httpClient, string organization, string credentials)
        {
            _urlBase = $"https://dev.azure.com/{organization}/";
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }

        public async Task<ProjectList> GetProjects()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_urlBase}{_urlProject}?{_urlApiSpec}");
            string ReadString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProjectList>(ReadString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<RepoList> GetRepos(Project project)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_urlBase}{project.id}{_urlRepo}?{_urlApiSpec}");
            string ReadString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<RepoList>(ReadString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }

    }
}
