using LevelUpAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpBackend.DataAccess
{
    public static class User
    {
        public static Users GetUserById(int id)
        {
            Users user;
            using (var dbcontext = new levelupContext())
            {
                user = dbcontext.Users.Where((user) => user.Id == id).FirstOrDefault();
            }
            return user;
        }
    }
}
