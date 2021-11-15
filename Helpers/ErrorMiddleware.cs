using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace team_double_trouble_backend.Helpers
{
    //Catches all errors and removes the need for multiple error handling code
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch(error)
                {
                    case AppException e:
                        // custom application specific errors that return "400 Bad Request"
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error returns "404 Not found"
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // any other exceptions are unhandled errors and return "500 Internal Server Error"
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}