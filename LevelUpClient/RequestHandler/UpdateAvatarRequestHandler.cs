using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class UpdateAvatarRequestHandler : RequestHandler<UpdateAvatarDTORequest>
    {
        public UpdateAvatarRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateAvatarDTORequest RequestBuilder()
        {
            return new ConsoleUpdateAvatarRequestBuilder()
                .WithNewSize()
                .Build();
        }
    }
}