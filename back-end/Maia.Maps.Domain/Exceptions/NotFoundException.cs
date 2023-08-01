using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public class NotFoundException : HttpStatusException
    {
        public NotFoundException(string? message, Exception? innerException = null) : base(HttpStatusCode.NotFound, message, innerException)
        {
        }
    }
}
