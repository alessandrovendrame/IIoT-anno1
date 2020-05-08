using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_20200427
{
    class MailSender:IMailSender
    {
        private IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;

        public MailSender(ILogger<Worker> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public void SendMessage(Activity activity)
        {
            var sender = _configuration.GetValue<string>("mailSettings:emailFrom");
            var emailTo = _configuration.GetValue<string>("mailSettings:emailTo");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Alessandro Vendrame", sender));
            message.To.Add(new MailboxAddress("Marco Collarini", emailTo));
            message.Subject = "NEW ACTIVITY";

            message.Body = new TextPart("plain")
            {
                Text = "Something to do: " + activity.ActivityProposed
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(sender, "");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}