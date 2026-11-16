[![NuGet](https://img.shields.io/nuget/v/AzureRetriever.svg)](https://www.nuget.org/packages/AzureRetriever)
# AzureRetriever

Small C# library I made to get a list of all Git repos in an Azure DevOps organization, across all projects.

```csharp
var repos = await AZRetriever.GetRepoList("organization", "", "personal-access-token");
```

You need a Personal Access Token from Azure DevOps with read access to Code and Projects. Disabled repos are skipped unless you pass `WantDisabled: true`.

The demo project uses a fake API response, so you can run it without an Azure account.
