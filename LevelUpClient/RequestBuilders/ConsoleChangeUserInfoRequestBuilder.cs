using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleChangeUserInfoRequestBuilder : RequestBuilder<ChangeUserInfoDTORequest>
    {
        public ConsoleChangeUserInfoRequestBuilder WithNewFirstname()
        {
            Console.Write("New Firstname (empty if no change): ");
            Request.NewFirstname = Console.ReadLine();
            return this;
        }

        public ConsoleChangeUserInfoRequestBuilder WithNewLastname()
        {
            Console.Write("New Lastname (empty if no change): ");
            Request.NewLastname = Console.ReadLine();
            return this;
        }

        public ConsoleChangeUserInfoRequestBuilder WithNewEmail()
        {
            Console.Write("New Email (empty if no change): ");
            Request.NewEmail = Console.ReadLine();
            return this;
        }

        public ConsoleChangeUserInfoRequestBuilder WithNewWeightKg()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("New Weight in kg (empty if no change): ");
                string newWeightkg_s = Console.ReadLine();
                if (newWeightkg_s == "" || newWeightkg_s == null)
                {
                    Request.NewWeightKg = null;
                    isOk = true;
                }
                else if (byte.TryParse(newWeightkg_s, out byte newWeightKg))
                {
                    Request.NewWeightKg = newWeightKg;
                    isOk = true;
                }
            }
            return this;
        }
    }
}
