using System.Collections.Generic;
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
            request.AddParameter("key", request.ApiKey);
        }

        public UserInformation GetInfo()
        {
            Request.Resource = string.Format("{0}/info.json", EndpointName);
            return Request.Execute<UserInformation>();
        }

        public string Ping()
        {
            Request.Resource = string.Format("{0}/ping.json", EndpointName);
            return Request.Execute();
        }

        public Ping2 Ping2()
        {
            Request.Resource = string.Format("{0}/ping2.json", EndpointName);
            return Request.Execute<Ping2>();
        }

        public List<SenderData> GetSenders()
        {
            Request.Resource = string.Format("{0}/senders.json", EndpointName);
            return Request.Execute<List<SenderData>>();
        }
    }
}