using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class GetAllSkinsRequestHandler : RequestHandler<GetAllSkinsDTORequest>
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