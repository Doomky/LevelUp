using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    internal class GetQuestTypesRequestHandler : RequestHandler<GetQuestTypesRequest>
    {
        public GetQuestTypesRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetQuestTypesRequest RequestBuilder()
        {
            return new ConsoleGetQuestTypesRequestBuilder()
                .Build();
        }
    }
}