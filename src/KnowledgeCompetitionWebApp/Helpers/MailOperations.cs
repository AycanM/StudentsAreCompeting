using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace KnowledgeCompetitionWebApp.Helpers
{
    public static class MailOperations
    {
        public static bool SendRegistrationMail(string to, string mailBody)
        {
            try
            {
                Encoding encoding = Encoding.GetEncoding("windows-1254");
                MailMessage Email = new MailMessage();
                MailAddress MailFrom = new MailAddress("ogrencileryarisiyor@gmail.com", "Öğrenciler Yarışıyor", encoding);

                Email.From = MailFrom;

                Email.To.Add(to);

                Email.Subject = "Öğrenciler Yarışıyor Parola Bilgilendirme";
                Email.Body = mailBody;

                Email.IsBodyHtml = true;

                SmtpClient smtpMail = new SmtpClient("smtp.gmail.com", 587);
                smtpMail.EnableSsl = true;
                smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpMail.UseDefaultCredentials = false;

                smtpMail.Credentials = new System.Net.NetworkCredential("ogrencileryarisiyor@gmail.com", "ogrencileryarisiyor2019");


                smtpMail.Send(Email);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


            return false;
        }
    }
}