using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class GetCurrentSkinRequestHandler : RequestHandler<GetCurrentSkinDTORequest>
    {
        public GetCurrentSkinRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetCurrentSkinDTORequest RequestBuilder()
        {
            return new ConsoleGetCurrentSkinRequestBuilder()
                .Build();
        }
    }
}