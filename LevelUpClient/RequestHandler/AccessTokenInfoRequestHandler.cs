using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    internal class AccessTokenInfoRequestHandler : RequestHandler<AccessTokenInfoRequest>
    {
        public AccessTokenInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AccessTokenInfoRequest RequestBuilder()
        {
            return new ConsoleAccessTokenInfoRequestBuilder()
                .Build();
        }
    }
}