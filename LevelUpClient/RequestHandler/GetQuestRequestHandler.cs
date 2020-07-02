using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestDTORequest>
    {
        public GetQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            if (Request.QuestState != null)
                FullAddress += "/" + Request.QuestState;
            base.Execute(httpClient);
        }

        public override GetQuestDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestRequestBuilder()
                    .WithQuestState()
                    .Build();
        }
    }
}
