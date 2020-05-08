using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CS_20200427
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMailSender _sendEmail;
        private readonly IConfiguration _conf;

        public Worker(ILogger<Worker> logger, IMailSender sendEmail, IConfiguration conf)
        {
            _logger = logger;
            _sendEmail = sendEmail;
            _conf = conf;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new WebClient();
                var result = client.DownloadString("http://www.boredapi.com/api/activity/");
                var activity = JsonConvert.DeserializeObject<Activity>(result, new JsonSerializerSettings()
                {
                    Error = (sender, e) =>
                    {
                        e.ErrorContext.Handled = true;
                    }
                });

                MailSender send = new MailSender(_logger, _conf);
                send.SendMessage(activity);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}