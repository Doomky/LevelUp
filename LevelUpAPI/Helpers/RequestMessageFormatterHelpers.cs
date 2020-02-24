using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpBackend.Helpers
{
    public static class RequestMessageFormatterHelpers
    {
        public static string ToLoggerMessage(HttpContext httpContext, string bodyAsStr = "")
        {
            using (StreamReader streamReader = new StreamReader(httpContext.Request.Body))
            {
                bodyAsStr = streamReader.ReadToEndAsync().Result;
            }  
            return String.Format(
@"[{0}]
Client IP: {1}
Method type: {2}
URL: {3}
Content Type: {4}
Body: {5}
",
                DateTime.Now,
                httpContext.Connection.LocalIpAddress.ToString(),
                httpContext.Request.Method,
                httpContext.Request.Path.Value,
                httpContext.Request.ContentType,
                bodyAsStr);
        }

    }
}
