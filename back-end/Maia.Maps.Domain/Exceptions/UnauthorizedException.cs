using System.Net;

namespace Maia.Maps.Domain.Exceptions
{
    public class UnauthorizedException : HttpStatusException
    {
        public UnauthorizedException(string? message) : base(HttpStatusCode.Unauthorized, message)
        {
        }
    }
}
