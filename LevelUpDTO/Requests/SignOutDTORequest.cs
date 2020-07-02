
namespace LevelUpDTO
{
    public class SignOutDTORequest : DTORequest
    {
        public string AccessToken { get; set; }

        public SignOutDTORequest() : base(Method.POST)
        {
        }
    }
}
