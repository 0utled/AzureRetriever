namespace AzureRetriever.Classes
{
    public class Repo
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public Project project { get; set; } = new Project();
        public string defaultBranch { get; set; } = string.Empty;
        public long size { get; set; }
        public string remoteUrl { get; set; } = string.Empty;
        public string sshUrl { get; set; } = string.Empty;
        public string webUrl { get; set; } = string.Empty;
        public bool? isFork { get; set; }
        public bool isDisabled { get; set; }
        public bool? isInMaintenance { get; set; }
    }
}
