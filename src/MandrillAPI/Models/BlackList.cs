using System.Collections.Generic;

namespace Mandrill.API.Models
{
    public class BlackList
    {
        private string email { get; set; }

        private string reason { get; set; }

        private string created_at { get; set; }

        private string expires_at { get; set; }

        private bool expired { get; set; }

        private List<string> Sender { get; set; }
    }
}