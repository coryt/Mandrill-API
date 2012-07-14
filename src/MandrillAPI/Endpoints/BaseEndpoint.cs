namespace Mandrill.API.Endpoints
{
    public class BaseEndpoint
    {
        protected readonly MandrillRequest Request;

        public BaseEndpoint(MandrillRequest request)
        {
            Request = request;
        }
    }
}