using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public class ForbiddenException : HttpStatusException
    {
        public ForbiddenException(string? message, Exception? innerException = null) : base(HttpStatusCode.Forbidden, message, innerException)
        {
        }
    }
}
