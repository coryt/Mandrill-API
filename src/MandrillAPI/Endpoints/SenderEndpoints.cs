using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Sender : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "senders";

        public Sender(MandrillRequest request) : base(request)
        {
        }

        /// <summary>"SenderList" returns a list of senders</summary>
        /// <returns>Return the senders that have tried to use this account.</returns>
        public List<SenderData> SenderList()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/list.json", EndpointName);


            return Request.Execute<List<SenderData>>();
        }

        /// <summary>"Domains" Returns the sender domains that have been added to this account.</summary>
        /// <returns>Return the senders that have tried to use this account.</returns>
        public List<SenderDomains> SenderDomains()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/domains.json", EndpointName);


            return Request.Execute<List<SenderDomains>>();
        }

        /// <summary>Info returns more detailed information about a single sender,
        /// including aggregates of recent stats</summary>
        /// <param name="key">the user api key</param>
        /// <param name="address">The email address of the sender</param>
        /// <returns>a struct of the detailed information about the sender</returns>
        public List<SenderData> SenderInfo(string Address)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/info.json", EndpointName);

            Request.AddBody(new {address = Address});

            return Request.Execute<List<SenderData>>();
        }

        /// <summary>"time-series" Return the recent history (hourly stats for the last 30 days) for a sender</summary>
        /// <param name="address">The email address of the sender</param>
        /// <returns>the array of history information</returns>
        public List<TimeSeriesStatistics> SenderTimeSeries(string Address)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/time-series.json", EndpointName);

            Request.AddBody(new {address = Address});

            return Request.Execute<List<TimeSeriesStatistics>>();
        }
    }
}