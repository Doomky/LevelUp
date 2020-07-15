using LevelUpAPI.DataAccess.GoogleFit;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.GoogleFit;
using LevelUpDTO.Requests;
using LevelUpDTO.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetSleepEntriesRequestHandler : RequestHandler<GetSleepEntriesDTORequest>
    {
        private readonly IUserRepository _userRepository;

        public GetSleepEntriesRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            ListSessionsRequest listSessionsRequest = new ListSessionsRequest();
            ListSessionstResponse listSessionstResponse = GoogleFitService.ListSessions(user, listSessionsRequest).GetAwaiter().GetResult();

            List<Session> sessions = listSessionstResponse.Sessions;


            List<GetSleepEntriesDTOResponse.SessionDTOResponse> sessionsReponseDTO = sessions.Select(
                session => new GetSleepEntriesDTOResponse.SessionDTOResponse(
                    session.Id,
                    session.Name,
                    session.Description,
                    session.StartTimeMillis,
                    session.EndTimeMillis,
                    session.ModifiedTimeMillis,
                    new GetSleepEntriesDTOResponse.SessionDTOResponse.AppliactionDTOResponse(
                        session.Application.PackageName,
                        session.Application.Version,
                        session.Application.DetailUrl,
                        session.Application.Name
                    ),
                    ((ActivityType)session.ActivityType).ToString(),
                    session.ActiveTimeMillis
            )).ToList();

            GetSleepEntriesDTOResponse responseDTO = new GetSleepEntriesDTOResponse(sessionsReponseDTO);

            string questsJson = JsonSerializer.Serialize(responseDTO.Sessions);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
