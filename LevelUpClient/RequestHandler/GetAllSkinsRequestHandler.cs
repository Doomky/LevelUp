using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class GetAllSkinsRequestHandler : RequestHandler<GetAllSkinsDTORequest>
    {
        public GetAllSkinsRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetAllSkinsDTORequest RequestBuilder()
        {
            return new ConsoleGetAllSkinsRequestBuilder()
                .Build();
        }
    }
}