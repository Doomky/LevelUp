using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordDTORequest, ChangePasswordDTOResponse>
    {
        public ChangePasswordRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ChangePasswordDTORequest RequestBuilder()
        {
            return new ConsoleChangePasswordRequestBuilder()
                .WithPassword()
                .WithNewPassword()
                .Build();
        }
    }
}
