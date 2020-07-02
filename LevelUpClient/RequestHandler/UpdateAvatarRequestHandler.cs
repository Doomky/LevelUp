using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    public class UpdateAvatarRequestHandler : RequestHandler<UpdateAvatarRequest>
    {
        public UpdateAvatarRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateAvatarRequest RequestBuilder()
        {
            return new ConsoleUpdateAvatarRequestBuilder()
                .WithNewSize()
                .Build();
        }
    }
}