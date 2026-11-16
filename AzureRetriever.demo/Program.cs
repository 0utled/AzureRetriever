using AzureRetriever;
using System.Net;

var fakeClient = new HttpClient(new FakeAzureHandler());
var repos = await AZRetriever.GetRepoList("fake-org", "", "fake-token", httpClient: fakeClient);

Console.WriteLine($"Found {repos.value.Count} repositories:");
foreach (var repo in repos.value)
    Console.WriteLine($"- {repo.project.name} / {repo.name} (disabled: {repo.isDisabled})");

Console.ReadLine();

class FakeAzureHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string url = request.RequestUri!.ToString();
        Console.WriteLine($"Request: {url}");

        string json = url.Contains("_apis/projects")
            ? """{"count":1,"value":[{"id":"11111111-1111-1111-1111-111111111111","name":"TestProject"}]}"""
            : """{"count":2,"value":[{"name":"RepoA","isDisabled":false,"project":{"name":"TestProject"}},{"name":"RepoB","isDisabled":true,"project":{"name":"TestProject"}}]}""";

        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json)
        });
    }
}