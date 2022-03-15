using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Interfaces;
using WS.Business.Models;
using WS.Data.Repository;

namespace WS.Business.Services
{
    public class ExecuteJobService
    {
        private readonly IJobService _jobService;
        public ExecuteJobService(IJobService jobService)
        {
            _jobService = jobService;
        }

        public string Execute()
        {
            callMongoDb();

            string message = "";
            foreach (var job in _jobService.JobsList)
            {
                if (CheckIfItCanRun(job))
                {
                    if (!job.Executed)
                        message += "\n\n" + _jobService.Execute(job);
                }
                else
                    job.Executed = false;
            }

            return message;
        }

        private void callMongoDb()
        {
            var jobSettings = new JobSettings()
            {
                ConnectionString = "mongodb+srv://brunodev:vmS9HW9l8roX0FwQ@cluster0.dzgbn.mongodb.net/TaskManager?retryWrites=true&w=majority",
                DatabaseName = "TaskManager",
                JobCollectionName = "Job"
            };

            Random rnd = new Random();
            int id = rnd.Next(1, 13000);

            var logRepository = new LogRepository(jobSettings);

            logRepository.Create(new Job()
            {
                Id = id,
                Command = "Comando "+ id,
                Description = "Description ...",
                Executed = true,
                Day = 14,
                Hour = 21,
                Minute = 01,
                Month = 03
            });



        }


        private bool CheckIfItCanRun(IJob job)
        {
            var now = DateTime.Now;

            if (job.Month.HasValue && job.Month != now.Month)
                return false;

            if (job.Day.HasValue && job.Day != now.Day)
                return false;

            if (job.Hour.HasValue && job.Hour != now.Hour)
                return false;

            if (job.Minute != now.Minute)
                return false;

            return true;
        }


    }
}
