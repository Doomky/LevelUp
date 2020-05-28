using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        public SignUpRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override SignUpRequest RequestBuilder()
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
