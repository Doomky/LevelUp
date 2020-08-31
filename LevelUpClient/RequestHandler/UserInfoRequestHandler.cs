using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class UserInfoRequestHandler : RequestHandler<UserInfoDTORequest, UserInfoDTOResponse>
    {
        public UserInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UserInfoDTORequest RequestBuilder()
        {
            return new ConsoleUserInfoRequestBuilder()
                .Build();
        }
    }
}
