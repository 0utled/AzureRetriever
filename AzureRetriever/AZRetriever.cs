using AzureRetriever.Classes;

namespace AzureRetriever
{
    public class AZRetriever
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static ProjectList ProjectList { get; set; } = new ProjectList();

        public static async Task<RepoList> GetRepoList(string organization, string auth_username, string auth_token, bool WantDisabled = false, HttpClient? httpClient = null)
        {
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", $"{auth_username}", $"{auth_token}")));
            Service service = new Service(httpClient ?? _httpClient, organization, credentials);
            ProjectList = await service.GetProjects();
            if (ProjectList != null)
            {
                RepoList ReturnRepoList = new RepoList();
                foreach (Project project in ProjectList.value)
                {
                    RepoList RepoList = await service.GetRepos(project);
                    if (RepoList != null)
                    {
                        ReturnRepoList.value.AddRange(RepoList.value.Where(r => WantDisabled || !r.isDisabled));
                        ReturnRepoList.count += RepoList.count;
                    }
                }
                return ReturnRepoList;
            }
            else
                return null;
        }
    }
}
