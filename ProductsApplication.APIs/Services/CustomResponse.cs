using System.Net;

namespace ProductsApplication.APIs
{
    public class CustomResponse
    {
        HttpStatusCode statusCode;
        string message = string.Empty;

        public CustomResponse(HttpStatusCode statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
