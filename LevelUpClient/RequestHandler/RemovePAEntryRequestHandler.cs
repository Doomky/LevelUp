using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    public class RemovePAEntryRequestHandler : RequestHandler<RemovePAEntryRequest>
    {
        public RemovePAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override RemovePAEntryRequest RequestBuilder()
        {
            return new ConsoleRemovePAEntryRequestBuilder()
                        .WithId()
                        .Build();
        }
    }
}
