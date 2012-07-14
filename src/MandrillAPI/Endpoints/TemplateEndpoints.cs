using System.Collections.Generic;
using Mandrill.API.Models;
using RestSharp;

namespace Mandrill.API.Endpoints
{
    public class Templates : BaseEndpoint, IMandrillEndpoint
    {
        private const string EndpointName = "templates";

        public Templates(MandrillRequest request)
            : base(request)
        {
        }

        /// <summary>Add a new template</summary>
        /// <param name="name">the name for the new template - must be unique</param>
        /// <param name="code">the HTML code with mc:edit attributes for the editable elements</param>
        /// <returns>the information saved about the new template</returns>
        public TemplateInfo Templateadd(string name, string code)
        {
            Request.Resource = string.Format("{0}/add.json", EndpointName);
            Request.AddBody(new {name, code});
            return Request.Execute<TemplateInfo>();
        }

        /// <summary>Get the information for an existing template</summary>
        /// <param name="name">the name of an existing template - must be unique</param>
        /// <returns>the information saved about the template</returns>
        public TemplateInfo Templateinfo(string name)
        {
            Request.Resource = string.Format("{0}/info.json", EndpointName);
            Request.AddBody(new {name});
            return Request.Execute<TemplateInfo>();
        }

        /// <summary>Update the code for an existing template</summary>
        /// <param name="name">the name of an existing template - must be unique</param>
        /// <param name="code">the new HTML code with mc:edit attributes for the editable elements</param>
        /// <returns>the information saved about the updated template</returns>
        public TemplateInfo update(string name, string code)
        {
            Request.Resource = string.Format("{0}/update.json", EndpointName);
            Request.AddBody(new {name, code});
            return Request.Execute<TemplateInfo>();
        }

        /// <summar>Delete a template</summar></summary>
        /// <param name="name">the name of an existing template</param>
        /// <returns>the information saved about the deleted template</returns>
        public TemplateInfo Templatedelete(string name)
        {
            Request.Resource = string.Format("{0}/delete.json", EndpointName);
            Request.AddBody(new {name});
            return Request.Execute<TemplateInfo>();
        }

        /// <summar>Delete a template</summar></summary>
        /// <returns>an array of the information about each template</returns>
        public List<TemplateInfo> Templatelist()
        {
            
            Request.Resource = string.Format("{0}/list.json", EndpointName);
            return Request.Execute<List<TemplateInfo>>();
        }

        /// <summar>Return the recent history (hourly stats for the last 30 days) for a template</summar></summary>
        /// <param name="name">the name of an existing template</param>
        /// <returns>the array of history information</returns>
        public List<TimeSeriesStatistics> TemplateTimeSeries(string name)
        {
            Request.Resource = string.Format("{0}/time-series.json", EndpointName);
            return Request.Execute<List<TimeSeriesStatistics>>();
        }
    }
}