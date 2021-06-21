using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using prosdocimus.Configuration;

namespace prosdocimus.Workers
{
    public class TwitterWorker : BackgroundService
    {
        private readonly ILogger<TwitterWorker> _logger;
        private readonly WorkerOptions _options;

        public TwitterWorker(ILogger<TwitterWorker> logger, ProsdocimusOptions options)
        {
            _logger = logger;
            _options = options.Worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_options.Enabled)
            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}