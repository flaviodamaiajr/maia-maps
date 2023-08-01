using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public class BadRequestException : HttpStatusException
    {
        public BadRequestException(string? message, Exception? innerException = null) : base(HttpStatusCode.BadRequest, message, innerException)
        {
        }
    }
}
