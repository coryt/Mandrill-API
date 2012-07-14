using System;
using Mandrill.API.Endpoints;
using RestSharp;

namespace Mandrill.API
{
    public class MandrillRequest : RestRequest
    {
        private const string MandrillUrl = "http://mandrillapp.com/api/1.0/";
        private readonly RestClient _client;

        private MandrillRequest(string apiKey)
        {
            ApiKey = apiKey;
            _client = new RestClient(MandrillUrl);
        }

        public string ApiKey { get; private set; }


        public static MandrillRequest With(string apiKey)
        {
            var request = new MandrillRequest(apiKey) { Method = Method.POST, RequestFormat = DataFormat.Json };

            return request;
        }

        public T In<T>() where T : IMandrillEndpoint
        {
            return (T)Activator.CreateInstance(typeof(T), this);
        }

        public T Execute<T>() where T : new()
        {
            try
            {
                IRestResponse<T> response = _client.Execute<T>(this);
                return response.Data;
            }
            catch
            {
                return default(T);
            }
        }

        public string Execute()
        {
            try
            {
                IRestResponse response = _client.Execute(this);
                return response.Content;
            }
            catch
            {
                return null;
            }
        }
    }
}