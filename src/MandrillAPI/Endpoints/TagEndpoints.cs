using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Tags : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "tags";

        public Tags(MandrillRequest request)
            : base(request)
        {
        }

        /// <summaryReturn all of the user-defined tag information</summary>
        /// <returns>Return the 100 most clicked URLs that match the search query given</returns>        
        public List<Tags> list()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/list.json", EndpointName);

            return Request.Execute<List<Tags>>();
        }

        /// <summaryReturn all of the user-defined tag information</summary>
        /// <param name="tag"> an existing tag name</param>
        /// <returns>struct of the detailed information about the tag</returns>        
        public List<DetailedTagsStatistics> info(string tag)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/info.json", EndpointName);
            Request.AddBody(new {tag});

            return Request.Execute<List<DetailedTagsStatistics>>();
        }

        /// <summaryReturn the recent history (hourly stats for the last 30 days) for a tag</summary>
        /// <param name="tag"> an existing tag name</param>
        /// <returns>struct of the detailed information about the tag</returns>        
        public List<TimeSeriesStatistics> TimeSeries(string tag)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/time-series.json", EndpointName);


            Request.AddBody(new {tag});

            return Request.Execute<List<TimeSeriesStatistics>>();
        }

        /// <summaryReturn the recent history (hourly stats for the last 30 days) for a tag</summary>
        /// <returns>struct of the detailed information about the tag</returns>        
        public List<TimeSeriesStatistics> AllTimeSeries()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/all-time-series.json", EndpointName);


            return Request.Execute<List<TimeSeriesStatistics>>();
        }
    }
}