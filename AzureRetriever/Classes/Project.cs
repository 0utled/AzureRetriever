namespace AzureRetriever.Classes
{
    public class Project
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public int revision { get; set; }
        public string visibility { get; set; } = string.Empty;
        public DateTime lastUpdateTime { get; set; }

    }
}
