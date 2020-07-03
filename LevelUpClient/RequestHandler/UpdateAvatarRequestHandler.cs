using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class UpdateAvatarRequestHandler : RequestHandler<UpdateAvatarDTORequest, UpdateAvatarDTOResponse>
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