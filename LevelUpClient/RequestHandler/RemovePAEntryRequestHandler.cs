using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class RemovePAEntryRequestHandler : RequestHandler<RemovePAEntryDTORequest>
    {
        public RemovePAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override RemovePAEntryDTORequest RequestBuilder()
        {
            return new ConsoleRemovePAEntryRequestBuilder()
                        .WithId()
                        .Build();
        }
    }
}
