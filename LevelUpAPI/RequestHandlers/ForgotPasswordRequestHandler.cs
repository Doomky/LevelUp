using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Security.Claims;

namespace LevelUpAPI.RequestHandlers
{
    public class ForgotPasswordRequestHandler : RequestHandler<ForgotPasswordDTORequest, ForgotPasswordDTOResponse>
    {
        public const string EMAIL_SECTION = "Email";
        public const string CLIENT_HOST_KEY = "Host";
        public const string CLIENT_Port_KEY = "Port";
        public const string EMAIL_FROM_KEY = "FromEmail";
        public const string EMAIL_DISPLAY_NAME_KEY = "DisplayName";

        public const string CRENDENTIAL_LOGIN_KEY = "Credential_login";
        public const string CRENDENTIAL_PASSWORD_KEY = "Credential_password";

        public const string PASSWORD_RECOVERY_URL = "http://localhost:44381/password-recovery/";
        public const string FRONT_PASSWORD_RECOVERY_URL = "http://localhost:3000/reset-password/";

        private readonly IUserRepository _userRepository;
        private readonly IPasswordRecoveryDataRepository _passwordRecoveryDataRepository;
        private readonly IConfiguration Configuration;

        public ForgotPasswordRequestHandler(ClaimsPrincipal claims, ForgotPasswordDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IPasswordRecoveryDataRepository passwordRecoveryDataRepository, IConfiguration configuration) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _passwordRecoveryDataRepository = passwordRecoveryDataRepository;
            Configuration = configuration;
        }

        protected async override Task<(ForgotPasswordDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null || (string.IsNullOrWhiteSpace(DTORequest.Login) && string.IsNullOrWhiteSpace(DTORequest.EmailAddress)))
                return (null, HttpStatusCode.BadRequest, null);

            User user = await _userRepository.GetUserByLoginOrEmail(DTORequest.Login, DTORequest.EmailAddress);

            if (user == null)
                return (null, HttpStatusCode.BadRequest, null);

            PasswordRecoveryData passwordRecoveryData = new PasswordRecoveryData()
            {
                UserId = user.Id,
                Date = DateTime.Now,
                Hash = string.Format("{0:X}", DateTime.Now.ToString().GetHashCode())
            };

            passwordRecoveryData = await _passwordRecoveryDataRepository.Insert(passwordRecoveryData);

            var section = Configuration.GetSection(EMAIL_SECTION);

            var client = new SmtpClient()
            {
                Host = section.GetValue<string>(CLIENT_HOST_KEY),
                Port = section.GetValue<int>(CLIENT_Port_KEY),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                    section.GetValue<string>(CRENDENTIAL_LOGIN_KEY),
                    section.GetValue<string>(CRENDENTIAL_PASSWORD_KEY))
            };

            MailAddress from = new MailAddress(
           section.GetValue<string>(EMAIL_FROM_KEY),
           section.GetValue<string>(EMAIL_DISPLAY_NAME_KEY),
           System.Text.Encoding.UTF8);

            MailAddress to = new MailAddress(user.Email);
            MailMessage message = new MailMessage(from, to);

            message.Body =
$@"Hi { user.Login},

You ask for a password recovery because you forgot your password.
In order to change your password, use the following link: { FRONT_PASSWORD_RECOVERY_URL + passwordRecoveryData.Hash }
You will be asked to enter your new password and to confirm this password.

Thanky you,

LevelUp";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "LevelUp - Password Recovery";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userState = "LevelUp - Password Recovery";
            client.SendAsync(message, userState);

            return (new ForgotPasswordDTOResponse(), HttpStatusCode.OK, null);
        }


        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            string token = (string)e.UserState;

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
