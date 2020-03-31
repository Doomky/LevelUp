using IdentityModel;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class ForgotPasswordRequestHandler : RequestHandler<ForgotPasswordRequest>
    {
        public const string EMAIL_SECTION = "Email";
        public const string CLIENT_HOST_KEY = "Host";
        public const string CLIENT_Port_KEY = "Port";
        public const string EMAIL_FROM_KEY = "FromEmail";
        public const string EMAIL_DISPLAY_NAME_KEY = "DisplayName";

        public const string CRENDENTIAL_LOGIN_KEY = "Credential_login";
        public const string CRENDENTIAL_PASSWORD_KEY = "Credential_password";

        public const string PASSWORD_RECOVERY_URL = "http://localhost:44381/password-recovery/";

        private readonly IUserRepository _userRepository;
        private readonly IPasswordRecoveryDataRepository _passwordRecoveryDataRepository;
        private readonly IConfiguration Configuration;

        public ForgotPasswordRequestHandler(IUserRepository userRepository, IPasswordRecoveryDataRepository passwordRecoveryDataRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordRecoveryDataRepository = passwordRecoveryDataRepository;
            Configuration = configuration;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            Dbo.User user = _userRepository.GetUserByLoginOrEmail(Request.Login, Request.EmailAddress).GetAwaiter().GetResult();
            if (user != null)
            {
                PasswordRecoveryData passwordRecoveryData = new PasswordRecoveryData()
                {
                    UserId = user.Id,
                    Date = DateTime.Now,
                    Hash = String.Format("{0:X}", DateTime.Now.ToString().GetHashCode())
                };

                passwordRecoveryData = _passwordRecoveryDataRepository.Insert(passwordRecoveryData).GetAwaiter().GetResult();

                var section = Configuration.GetSection(EMAIL_SECTION);

                var client = new System.Net.Mail.SmtpClient()
                {
                    Host = section.GetValue<string>(CLIENT_HOST_KEY),
                    Port = section.GetValue<int>(CLIENT_Port_KEY),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(
                        section.GetValue<string>(CRENDENTIAL_LOGIN_KEY),
                        section.GetValue<string>(CRENDENTIAL_PASSWORD_KEY))
                };

                {
                    MailAddress from = new MailAddress(
                   section.GetValue<string>(EMAIL_FROM_KEY),
                   section.GetValue<string>(EMAIL_DISPLAY_NAME_KEY),
                   System.Text.Encoding.UTF8);

                    MailAddress to = new MailAddress(user.Email);
                    MailMessage message = new MailMessage(from, to);

                    message.Body =
$@"Hi { user.Login},

You ask for a password recovery because you forgot your password.
In order to change your password, use the following link: { PASSWORD_RECOVERY_URL + passwordRecoveryData.Hash }
You will be asked to enter your new password and to confirm this password.

Thanky you,

LevelUp";
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "LevelUp - Password Recovery";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userState = "LevelUp - Password Recovery";
                    client.SendAsync(message, userState);
                }
            }
        }


        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}
