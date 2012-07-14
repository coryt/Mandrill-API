using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Webhooks : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "webhooks";

        public Webhooks(MandrillRequest request)
            : base(request)
        {
        }

        /// <summary>Get the list of all webhooks defined on the account</summary>
        /// <returns>A struct of the webhook information</returns>
        public WebhookInfo Webhookslist()
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/list.json", EndpointName);

            return Request.Execute<WebhookInfo>();
        }


        /// <summary>Add a new webhook</summary>
        /// <param name="url">the URL to POST batches of events</param>
        /// <param name="T">an optional list of events that will be posted to the webhook</param>
        /// <returns>the information saved about the new webhook</returns>
        public WebhookInfo Webhooksadd(string url, List<object> T)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/add.json", EndpointName);
            Request.AddBody(new {message = T});

            return Request.Execute<WebhookInfo>();
        }

        /// <summary>Given the ID of an existing webhook, return the data about it</summary>
        /// <param name="id">the unique identifier of a webhook belonging to this account</param>
        /// <returns>Return the information about the Webhook</returns>
        public WebhookInfo Webhooksinfo(int id)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/info.json", EndpointName);
            Request.AddBody(new {id});

            return Request.Execute<WebhookInfo>();
        }

        /// <summary>Update an existing webhook</summary>
        /// <param name="id">the unique identifier of a webhook belonging to this account</param>
        /// <param name="url">the URL to POST batches of events</param>
        /// <param name="T">an optional list of events that will be posted to the webhook</param>
        /// <returns>the information for the updated webhook</returns>
        public WebhookInfo Webhooksupdate(int id, string url, List<object> T)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/update.json", EndpointName);
            Request.AddBody(new {id, url, events = T});

            return Request.Execute<WebhookInfo>();
        }

        /// <summary>Delete an existing webhook</summary>
        /// <param name="id">the unique identifier of a webhook belonging to this account</param>
        /// <returns>the information for the deleted webhook</returns>
        public WebhookInfo Webhooksdelete(int id)
        {
            Request.Method = Method.POST;
            Request.Resource = string.Format("{0}/delete.json", EndpointName);
            Request.AddBody(new {id});

            return Request.Execute<WebhookInfo>();
        }
    }
}