using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;


namespace VmgPortal.Library.Utilities
{
    public class EmailUtility
    {
        public static bool DoSendMail(string toList, string ccList, string subject, string content)
        {

            string userName = AppEnv.GetSetting("Mail_UserName");
            string from = AppEnv.GetSetting("Mail_From");
            string password = AppEnv.GetSetting("Mail_Password");
            string server = AppEnv.GetSetting("Mail_Server");
            int port = ConvertUtility.ToInt32(AppEnv.GetSetting("Mail_Port"));

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                {
                    message.CC.Add(ccList);
                }
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                smtpClient.Host = server;
                smtpClient.Port = port;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(userName, password);

                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
