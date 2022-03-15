using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WS.Business.Interfaces;
using WS.Business.Models;
using WS.Business.Services;

namespace WS.Timer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerOptions _options;
        

        public Worker(ILogger<Worker> logger, WorkerOptions options)
        {
            _logger = logger;
            _options = options;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("O serviço está iniciando.");
            stoppingToken.Register(() => _logger.LogInformation("Tarefa de segundo plano está parando."));

            // Create a management Jobs
            ExecuteJobService jobService = new ExecuteJobService(GetJobService());

            while (!stoppingToken.IsCancellationRequested)
            {
                // Run My Jobs
                string message = jobService.Execute();
                _logger.LogInformation(message);
                await Task.Delay(_options.Seconds, stoppingToken);

                _logger.LogInformation("{time}", DateTimeOffset.Now);
            }

            _logger.LogInformation("O serviço está parando.");
        }

        public IJobService GetJobService()
        {
            if(_options.Type.Equals("SQLJob"))
            {
                // Get My Jobs
                JobSQLService jobSQLService = new JobSQLService();
                jobSQLService.GetJobs();
                return jobSQLService;
            }

            if (_options.Type.Equals("FileJob"))
            {
                return new JobFileService(
                     _options.fileJobOptions.Select(x =>
                     {
                         return new JobFile()
                         {
                             PathDirectoryDestiny = x.PathDirectoryDestiny,
                             PathDirectoryOrigin = x.PathDirectoryOrigin,
                             Minute = x.Minute
                         };
                     })
                );
            }

            throw new NotImplementedException();
           

        }


    }
}
