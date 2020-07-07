using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestDTORequest, GetQuestDTOResponse>
    {
        public GetQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override DTOResponse Execute(HttpClient httpClient)
        {
            if (DTORequest.QuestState != null)
                FullAddress += "/" + DTORequest.QuestState;
            return base.Execute(httpClient);
        }

        public override GetQuestDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestRequestBuilder()
                    .WithQuestState()
                    .Build();
        }
    }
}
