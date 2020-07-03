using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    public class SignUpRequestHandler : RequestHandler<SignUpDTORequest, SignUpDTOResponse>
    {
        public SignUpRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override SignUpDTORequest RequestBuilder()
        {
            return new ConsoleSignUpRequestBuilder()
                    .WithLogin()
                    .WithPassword()
                    .WithFirstname()
                    .WithLastname()
                    .WithGender()
                    .WithEmailAddress()
                    .Build();
        }
    }
}
