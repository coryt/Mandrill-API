namespace Mandrill.API.Models
{
    public class Summary
    {
        public Statistics today { get; set; }
        public Statistics last_7_days { get; set; }
        public Statistics last_30_days { get; set; }
        public Statistics last_60_days { get; set; }
        public Statistics last_90_days { get; set; }
        public Statistics all_time { get; set; }
    }
}