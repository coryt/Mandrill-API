namespace Mandrill.API.Models
{
    public class WebhookInfo
    {
        public int id { get; set; }

        public string url { get; set; }

        public string created_at { get; set; }

        public string last_sent_at { get; set; }

        public int batches_sent { get; set; }

        public int events_sent { get; set; }

        public string last_error { get; set; }
    }
}