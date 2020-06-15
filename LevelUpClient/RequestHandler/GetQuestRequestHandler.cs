using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestRequest>
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

        public override GetQuestRequest RequestBuilder()
        {
            return new ConsoleGetQuestRequestBuilder()
                    .WithQuestState()
                    .Build();
        }
    }
}
