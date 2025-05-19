﻿using MailKit.Net.Smtp;
using MimeKit;
using OrderingSystem.Data.Helpers;
using OrderingSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Service.Implementations
{
    public class EmailService:IEmailService
    {

        #region fields
        private readonly EmailSettings _emailSettings;
        #endregion
        #region ctor
        public EmailService(EmailSettings emailSettings)
        {
           _emailSettings = emailSettings;
        }
        #endregion
        #region function
        public async Task<string> SendEmail(string email, string Message, string? reason)
        {
            try
            {


                //sending the message of passwordRestLink
                using (var client = new SmtpClient())
                {
                   await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "Wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("Testing", email));
                    message.Subject = reason==null?"No Submitted":reason;
                    await client.SendAsync(message);
                   await client.DisconnectAsync(true);
                }
                //end of sendig email
                return "Success";
            }
            catch (Exception ex) 
            {
                return "Failed";
            }

        }
        #endregion
    }
}
