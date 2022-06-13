using System.Net.Mail;
namespace Identity.Web.Helper
{
    public class PasswordReset
    {
        public static void PasswordResetSendEmail(string link, string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.example.com");
            mail.From = new MailAddress("berkancelikist@gmail.com");
            mail.To.Add(email);
            mail.Subject = $"www.bıdı.com: Şifre sıfırlama";
            mail.Body = "<h2> Şifrenizi yenilemek için lütfen aşağıdkai linke tıklayımız</h2><hr/>";
            mail.Body+=$"<a href='{link}'>şifre yenileme linki</a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("berkancelikist@gmail.com", "Berkan123");
            smtpClient.Send(mail);
        }
    }
}
