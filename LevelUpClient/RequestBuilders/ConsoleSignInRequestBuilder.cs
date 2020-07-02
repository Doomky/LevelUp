using IdentityModel;
using LevelUpDTO;
using System;
using System.Net.Mail;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSignInRequestBuilder : RequestBuilder<SignInDTORequest>
    {
        public ConsoleSignInRequestBuilder WithLoginOrEmailAddress()
        {
            Console.Write("Login or Email Address:");
            string result = Console.ReadLine();
            try
            {
                MailAddress mailAddress = new MailAddress(result);
                Request.EmailAddress = mailAddress.Address;
            }
            catch (FormatException)
            {
                Request.Login = result;
            }
            return this;
        }

        public ConsoleSignInRequestBuilder WithPasswordOrPasswordHash()
        {
            int selection = -1;
            while (selection == -1)
            {
                Console.WriteLine("Please select:");
                Console.WriteLine("1 - Password");
                Console.WriteLine("2 - PasswordHash");
                string result = Console.ReadLine();
                try
                {
                    if (int.TryParse(result, out selection))
                        if (selection != 1 && selection != 2)
                            selection = -1;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            switch (selection)
            {
                case 1:
                    return WithPassword();
                case 2:
                    return WithPasswordHash();
                default:
                    throw new Exception();
            }
        }

        public ConsoleSignInRequestBuilder WithPassword()
        {
            Console.Write("Password (will be hashed):");
            Request.PasswordHash = Console.ReadLine().ToSha256();
            return this;
        }

        public ConsoleSignInRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash:");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }

    }
}
