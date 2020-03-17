using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.OpenFoodFacts.Login
{
    public interface ILoginApi
    {
        bool IsLoggedIn { get; }

        Task<bool> LoginAsync(string user, string pass);
        Task<bool> LogoutAsync();
    }
}
