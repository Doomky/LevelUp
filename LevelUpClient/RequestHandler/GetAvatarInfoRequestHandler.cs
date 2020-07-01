using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    internal class GetAvatarInfoRequestHandler : RequestHandler<GetAvatarInfoRequest>
    {
        public GetAvatarInfoRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetAvatarInfoRequest RequestBuilder()
        {
            return new ConsoleGetAvatarInfoRequestBuilder()
                .Build();
        }
    }
}