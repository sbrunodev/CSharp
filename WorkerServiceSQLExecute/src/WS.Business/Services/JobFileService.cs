using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Interfaces;
using WS.Business.Models;

namespace WS.Business.Services
{
    public class JobFileService : IJobService
    {
        public IEnumerable<IJob> JobsList { get; set; }

        public JobFileService(IEnumerable<JobFile> jobFile) : base()
        {
            JobsList = jobFile;
        }

        public string Execute(IJob job)
        {
            var jobFile = (JobFile)job;

            job.Executed = true;
            jobFile.Executed = true;

            string message = $@"
            Executing in {DateTime.Now}
            Job: {job.Id} - {job.Description} - Time for Execute: Minute:{job.Minute}
            Files copied from {jobFile.PathDirectoryOrigin} to {jobFile.PathDirectoryDestiny}
            ";

            return message;
        }


        public void GetJobs()
        {
            throw new NotImplementedException();
        }
    }
}
