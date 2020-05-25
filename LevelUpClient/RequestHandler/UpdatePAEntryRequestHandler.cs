using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    public class UpdatePAEntryRequestHandler : RequestHandler<UpdatePAEntryRequest>
    {
        public UpdatePAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdatePAEntryRequest RequestBuilder()
        {
            return new ConsoleUpdatePAEntryRequestBuilder()
                        .WithId()
                        .WithNewName()
                        .WithNewKCalPerHour()
                        .Build();
        }
    }
}