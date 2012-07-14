namespace Mandrill.API.Models
{
    public class SearchReturn
    {
        public int ts { get; set; }
        public string sender { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string[] tags { get; set; }
        public int opens { get; set; }
        public int clicks { get; set; }
        public string state { get; set; }
    }
}