using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class GetQuestTypesRequestHandler : RequestHandler<GetQuestTypesDTORequest>
    {
        public GetQuestTypesRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetQuestTypesDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestTypesRequestBuilder()
                .Build();
        }
    }
}