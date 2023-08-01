using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public abstract class HttpStatusException : ApplicationException
    {
        protected HttpStatusException(HttpStatusCode status, string? message, Exception? innerException = null) : base(message, innerException)
        {
            Status = status;
        }

        public HttpStatusCode Status { get; set; }
    }
}
