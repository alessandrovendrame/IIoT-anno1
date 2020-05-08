using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_20200427
{
    public interface IMailSender
    {
        public void SendEmail();
    }
}
