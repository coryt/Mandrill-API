using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Messages : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "messages";

        public Messages(MandrillRequest request)
            : base(request)
        {
        }

        /// <summary>Send will send a new transactional message through Mandrill</summary>
        /// <param name="T">The message data</param>
        /// <returns>A struct of type RecipientReturn</returns>
        public List<RecipientReturn> send(object T)
        {
            Request.Resource = string.Format("{0}/send.json", EndpointName);
            Request.AddBody(new { key = Request.ApiKey, message = T });
            
            return Request.Execute<List<RecipientReturn>>();
        }

        /// <summary>Sendtemplate will Send a new transactional message through Mandrill using a template</summary>
        /// <param name="TemplateName">A string value of the name of the template</param>
        /// <param name="templateContent">An array of template content</param>
        /// <param name="message">A message struct of the other info to send (same as messagesend w/out the html)</param>
        /// <returns>A struct of type RecipientReturn</returns>
        public List<RecipientReturn> sendtemplate(string TemplateName, List<object> templateContent, object message)
        {
            Request.Resource = string.Format("{0}/send-template.json", EndpointName);
            Request.AddBody(new { key = Request.ApiKey, template_name = TemplateName, template_content = templateContent, message });
            
            return Request.Execute<List<RecipientReturn>>();
        }

        /// <summary>Search the content of recently sent messages and optionally narrow by date range, tags and senders</summary>
        /// <param name="query">the search items to find matching messages to</param>
        /// <param name="date_from">start date</param>
        /// <param name="date_to">end date</param>
        /// <param name="tags">array of string containing tag names</param>
        /// <param name="senders">array of senders addresses</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>A struct of type RecipientReturn</returns>
        public List<SearchReturn> search(string query, string date_from, string date_to, List<string> tags,
                                         List<string> senders, int limit)
        {
            Request.Resource = string.Format("{0}/search.json", EndpointName);
            Request.AddBody(new { key = Request.ApiKey, query, date_from, tags, senders, limit });

            return Request.Execute<List<SearchReturn>>();
        }
    }
}