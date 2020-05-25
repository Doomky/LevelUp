
namespace LevelUpRequests
{
    public class SignOutRequest : Request
    {
        public string AccessToken { get; set; }

        public SignOutRequest() : base(Method.POST)
        {
        }
    }
}
