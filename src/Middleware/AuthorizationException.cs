using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Middleware
{
    public sealed class AuthorizationException : Exception 
    {
        public AuthorizationException(int code, string message) : base(message)
        {
            StatusCode = code;
        }
        public int StatusCode { get; set; }

        public async Task SetError(HttpContext context)
        {
            context.Response.StatusCode = StatusCode;
            await context.Response.WriteAsync(Message);
        }
    }
}
