using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Maia.Maps.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public Result Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = context?.Error;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case InvalidOperationException:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new Result(isValid: false, exception.Message);

                case ValidationException validationException:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new ValidationResult(validationException);

                case HttpStatusException httpStatusException:
                    Response.StatusCode = (int)httpStatusException.Status;
                    return new Result(isValid: false, httpStatusException.Message);
            }

            _logger.LogError(exception, "Unexpected request error.");

            return new Result(isValid: false, message: "An unexpected error occurred in the request.");
        }
    }
}

