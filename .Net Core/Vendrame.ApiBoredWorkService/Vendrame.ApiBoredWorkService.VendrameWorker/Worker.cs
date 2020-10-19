using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Vendrame.ApiBoredWorkService.VendrameWorker
{
    public class Worker : BackgroundService
    {
            private readonly ILogger<Worker> _logger;
            private readonly IConfiguration _conf;

            public Worker(ILogger<Worker> logger, IConfiguration conf)
            {
                _logger = logger;
                _conf = conf;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var client = new WebClient();
                    var result = client.DownloadString("http://www.boredapi.com/api/activity/");
                    var res = JsonConvert.DeserializeObject<Activity>(result, new JsonSerializerSettings()
                    {
                        Error = (sender, e) =>
                        {
                            e.ErrorContext.Handled = true;
                        }
                    });

                    var myActivityModel = new ActivityModel
                    {
                        ActivityType = res.ActivityProposed,
                        Type = res.Type
                    };

                    string activity = JsonConvert.SerializeObject(myActivityModel);
                    using (var httpClientHandler = new HttpClientHandler())
                    {
                        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                        using (var c = new HttpClient(httpClientHandler))
                        {
                            var data = new StringContent(activity, Encoding.UTF8, "application/json");

                            var url = "https://localhost:44322/api/Activity";

                            var response = await c.PostAsync(url, data);
                        }
                    }

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }
    }
