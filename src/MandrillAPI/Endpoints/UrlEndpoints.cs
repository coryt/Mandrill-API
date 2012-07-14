using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Urls : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "urls";

        public Urls(MandrillRequest request)
            : base(request)
        {
        }

        /// <summary>Get the 100 most clicked URLs</summary>
        /// <returns>the 100 most clicked URLs and their stats</returns>        
        public List<URLStats> UrlList()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/list.json", EndpointName);


            return Request.Execute<List<URLStats>>();
        }

        /// <summary>Return the 100 most clicked URLs that match the search query given</summary>
        /// <param name="q">a search query</param>
        /// <returns>the 100 most clicked URLs and their stats</returns>        
        public List<URLStats> UrlSearch(string q)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/search.json", EndpointName);

            Request.AddBody(new {q});

            return Request.Execute<List<URLStats>>();
        }

        /// <summary>Return the recent history (hourly stats for the last 30 days) for a url</summary>
        /// <param name="url">an existing url</param>
        /// <returns>the array of history information</returns>        
        public List<URLHistory> UrlTimeSeries(string url)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/time-series.json", url);


            return Request.Execute<List<URLHistory>>();
        }
    }
}