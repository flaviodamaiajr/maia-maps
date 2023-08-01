using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public class ConflictRequestException : HttpStatusException
    {
        public ConflictRequestException(string? message, Exception? innerException = null) : base(HttpStatusCode.Conflict, message, innerException)
        {
        }
    }
}
