using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;

namespace LevelUpAPI
{
    public abstract class RequestHandler<TDTORequest, TDTOResponse> where TDTORequest : DTORequest, new() where TDTOResponse : DTOResponse
    {
        protected TDTORequest DTORequest { get; set; }
        protected TDTOResponse DTOResponse { get; set; }

        protected virtual async Task<HttpContext> CheckHeader(HttpContext context)
        {
            return await Task.FromResult(context); 
        }
        protected virtual async Task<HttpContext> CheckBody(HttpContext context)
        {
            DTORequest = new TDTORequest();
            if (DTORequest.GetMethodType() == LevelUpDTO.DTORequest.Method.POST)
            {
                string bodyStr = "";
                Stream body = context.Request.Body;
                using (StreamReader reader = new StreamReader(body))
                {
                    bodyStr = await reader.ReadToEndAsync();
                }
                DTORequest = JsonSerializer.Deserialize<TDTORequest>(bodyStr);
            }
            return context;
        }

        protected virtual async Task<TDTOResponse> ExecuteRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<TDTOResponse> Execute(HttpContext context)
        {
            try
            {
                context = await CheckHeader(context);
                if (context == null)
                    return null;
                context = await CheckBody(context);
                if (context == null)
                    return null;
                return await ExecuteRequest(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }

        public TDTOResponse GetDTOResponse()
        {
            return DTOResponse;
        }
    }
}
