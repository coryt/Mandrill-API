using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Rejects : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "rejects";

        public Rejects(MandrillRequest request)
            : base(request)
        {
        }

        /// <summary>Retrieves your email rejection blacklist. You can provide an email
        /// address to limit the results. Returns up to 1000 results</summary>
        /// <param name="Email">an optional email address to search by</param>
        /// <returns>the information for each rejection blacklist entry</returns>
        public List<BlackList> list(string Email)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/list.xml", EndpointName);
            Request.AddBody(new {email = Email});

            return Request.Execute<List<BlackList>>();
        }

        /// <summary>Deletes an email rejection. There is no limit to how many rejections
        /// you can remove from your blacklist, but keep in mind that each deletion  
        /// has an affect on your reputation.</summary>
        /// <param name="Email">an email address</param>
        /// <returns>a status object containing the address and whether the deletion succeeded.</returns>
        public List<DeletedSuccesses> delete(string Email)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/delete.xml", EndpointName);
            Request.AddBody(new {email = Email});

            return Request.Execute<List<DeletedSuccesses>>();
        }
    }
}