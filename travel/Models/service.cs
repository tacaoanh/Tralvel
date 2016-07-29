using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace travel.Models
{
    public class service
    {
        /// <summary>
        /// Gửi mail liên hệ
        /// </summary>
        /// <param name="smtpUserName">Tên đăng nhập Email Gửi thư thư</param>
        /// <param name="smtpPassword">Mật khẩu của Email Gửi thư</param>
        /// <param name="smtpHost">Host Mail-Smtp.gmail.com</param>
        /// <param name="smtpPort">Cổng</param>
        /// <param name="toEmail">Email nhận thư</param>
        /// <param name="subject">Chủ đề thư</param>
        /// <param name="body">Nội dung thư gửi</param>
        /// <returns></returns>
        public bool Send(string smtpUserName, string smtpPassword, string smtpHost, int smtpPort, string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = smtpPort;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };

                    msg.To.Add(toEmail);

                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}