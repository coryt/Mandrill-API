namespace Mandrill.API.Models
{
    public class Statistics
    {
        public int sent { get; set; }
        public int hard_bounces { get; set; }
        public int soft_bounces { get; set; }
        public int rejects { get; set; }
        public int complaints { get; set; }
        public int unsubs { get; set; }
        public int opens { get; set; }
        public int unique_opens { get; set; }
        public int clicks { get; set; }
        public int unique_clicks { get; set; }
    }

    public class TagStatistics : Statistics
    {
        public string Tag { get; set; }
    }

    public class TimeSeriesStatistics : Statistics
    {
        private string time { get; set; }
    }

    public class SenderData : Statistics
    {
        public string address { get; set; }

        public string created_at { get; set; }

        public bool is_enabled { get; set; }
    }

    public class DetailedTagsStatistics : Statistics
    {
        private string tag { get; set; }

        private Summary stats { get; set; }
    }
}