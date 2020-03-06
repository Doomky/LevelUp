using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;

namespace LevelUpAPI
{
    public abstract class RequestHandler<TRequest> where TRequest : Request
    {
        protected TRequest Request { get; set; }

        protected virtual async Task<HttpContext> CheckHeader(HttpContext context)
        {
            return await Task<HttpContext>.FromResult(context); 
        }
        protected virtual async Task<HttpContext> CheckBody(HttpContext context)
        {
            string bodyStr = "";
            Stream body = context.Request.Body;
            using (StreamReader reader = new StreamReader(body))
            {
                bodyStr = await reader.ReadToEndAsync();
            }
            Request = JsonSerializer.Deserialize<TRequest>(bodyStr);
            return context;
        }

        protected virtual async void ExecuteRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public async void Execute(HttpContext context)
        {
            try
            {
                context = await CheckHeader(context);
                if (context == null)
                    return;
                context = await CheckBody(context);
                if (context == null)
                    return;
                ExecuteRequest(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
