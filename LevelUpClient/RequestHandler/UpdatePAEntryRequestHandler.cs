using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class UpdatePAEntryRequestHandler : RequestHandler<UpdatePAEntryDTORequest>
    {
        public UpdatePAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdatePAEntryDTORequest RequestBuilder()
        {
            return new ConsoleUpdatePAEntryRequestBuilder()
                        .WithId()
                        .WithNewDatetimeStart()
                        .WithNewDatetimeEnd()
                        .Build();
        }
    }
}