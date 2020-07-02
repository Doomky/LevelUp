using IdentityModel;
using LevelUpDTO;
using System;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSignUpRequestBuilder : RequestBuilder<SignUpDTORequest>
    {
        public ConsoleSignUpRequestBuilder WithLogin()
        {
            Console.Write("Login: ");
            Request.Login = Console.ReadLine();
            return this;
        }


        public ConsoleSignUpRequestBuilder WithFirstname()
        {
            Console.Write("Firstname:");
            Request.Firstname = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithLastname()
        {
            Console.Write("Lastname:");
            Request.Lastname = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithGender()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("Gender (0 for male, 1 for female, nothing for other):");
                string gender = Console.ReadLine();
                switch (gender)
                {
                    case "0":
                        Request.Gender = false; // male
                        isOk = true;
                        break;
                    case "1":
                        Request.Gender = true; // female
                        isOk = true;
                        break;
                    case "":
                    case null:
                        Request.Gender = null; // other
                        isOk = true;
                        break;
                    default:
                        break;
                }
            }
            return this;
        }

        public ConsoleSignUpRequestBuilder WithEmailAddress()
        {
            Console.Write("Email Adrress:");
            Request.EmailAddress = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithPasswordHash()
        {
            Console.Write("Password Hash:");
            Request.PasswordHash = Console.ReadLine();
            return this;
        }

        public ConsoleSignUpRequestBuilder WithPassword()
        {
            Console.Write("Password (will be hashed):");
            String password = Console.ReadLine();
            Request.PasswordHash = password.ToSha256();
            return this;
        }
    }
}
