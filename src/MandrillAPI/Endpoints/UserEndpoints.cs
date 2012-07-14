using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Users : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "users";

        public Users(MandrillRequest request)
            : base(request)
        {
        }

        public UserInformation GetInfo()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/info.json", EndpointName);
            return Request.Execute<UserInformation>();
        }

        public string Ping()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/ping.json", EndpointName);
            return Request.Execute();
        }

        public string Ping2()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/ping2.json", EndpointName);
            return Request.Execute();
        }

        public string GetSenders()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/senders.json", EndpointName);
            return Request.Execute();
        }
    }
}