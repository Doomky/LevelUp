using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class GetAvatarInfoRequestHandler : RequestHandler<GetAvatarInfoDTORequest, GetAvatarInfoDTOResponse>
    {
        public GetAvatarInfoRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetAvatarInfoDTORequest RequestBuilder()
        {
            return new ConsoleGetAvatarInfoRequestBuilder()
                .Build();
        }
    }
}