using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetAllSkinsRequestHandler : RequestHandler<GetAllSkinsDTORequest>
    {
        private readonly ISkinRepository _skinRepository;

        public GetAllSkinsRequestHandler(ISkinRepository skinRepository)
        {
            _skinRepository = skinRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            IEnumerable<Skin> skins = _skinRepository.GetAll().GetAwaiter().GetResult();

            if (skins != null)
            {
                string skinsJson = JsonSerializer.Serialize(skins);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(skinsJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
