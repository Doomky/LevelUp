using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LevelUpDTO;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace LevelUpAPI
{
    public abstract class RequestHandler<TDTORequest, TDTOResponse> 
        where TDTORequest : DTORequest
        where TDTOResponse : DTOResponse
    {
        protected TDTORequest DTORequest { get; set; }

        protected ILogger Logger { get; set; }

        protected ClaimsPrincipal Claims { get; set; }

        protected RequestHandler(ClaimsPrincipal claims, TDTORequest dTORequest, ILogger logger)
        {
            Claims = claims;
            DTORequest = dTORequest;
            Logger = logger;
        }

        protected virtual async Task<(TDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            throw new NotImplementedException();
        }

        public async Task<(TDTOResponse response, HttpStatusCode statusCode, string errorMessage)> Handle()
        {
            try
            {
                return await Handle_Internal();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return (null, HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
