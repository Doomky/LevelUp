using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class SelectSkinRequestHandler : RequestHandler<SelectSkinDTORequest>
    {
        public SelectSkinRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override SelectSkinDTORequest RequestBuilder()
        {
            return new ConsoleSelectSkinRequestBuilder()
                .WithId()
                .Build();
        }
    }
}