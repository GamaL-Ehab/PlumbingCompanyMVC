using EntityLayer.Identity.ViewModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
    public interface ISendEmailMethod
    {
        Task SendPasswordResetLinkWithToken(string passwordResetLink, string toEmail);
    }
    public class SendEmailMethod : ISendEmailMethod
    {

        private readonly GmailInformationVM _gmailInformation;
        public SendEmailMethod(IOptions<GmailInformationVM> gmailInformation)
        {
            _gmailInformation = gmailInformation.Value;
        }

        public async Task SendPasswordResetLinkWithToken(string passwordResetLink, string toEmail)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = _gmailInformation.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmailInformation.Email, _gmailInformation.Password);

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_gmailInformation.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Reset Password | Plumbing Company";
            mailMessage.Body = $@"<h1>Password Reset Link</h1>
                                  <h2>Click <a href='{passwordResetLink}'>HERE</a> To Reset Password.</h2>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
