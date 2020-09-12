using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class GetAvailableSkinsRequestHandler : RequestHandler<GetAvailableSkinsDTORequest>
    {
        public GetAvailableSkinsRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetAvailableSkinsDTORequest RequestBuilder()
        {
            return new ConsoleGetAvailableSkinsRequestBuilder()
                .Build();
        }
    }
}