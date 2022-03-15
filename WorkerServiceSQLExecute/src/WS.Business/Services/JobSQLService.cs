using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Interfaces;
using WS.Business.Models;

namespace WS.Business.Services
{
    public class JobSQLService : IJobService
    {
        public IEnumerable<IJob> JobsList { get; set; }

        public JobSQLService()
        {

        }

        public string Execute(IJob job)
        {
            job.Executed = true;

            string message = $@"
            Executing in {DateTime.Now}
            Job: {job.Id} - {job.Description} - Time for Execute: Minute:{job.Minute}
            Command: {job.Command}
            ";

            return message;
        }

        private List<Job> GenerateFakeJobs()
        {
            List<Job> jobsList = new List<Job>();
            for (int i = 0; i < 60; i++)
            {
                jobsList.Add(new Job()
                {
                    Id = 1,
                    Description = "Limpeza na tabela Eventos",
                    Command = "TRUNCATE TABLE EVENTOS",
                    Month = null,
                    Day = null,
                    Hour = null,
                    Minute = i
                });
            }

            return jobsList;
        }

        public void GetJobs()
        {
            // TODO : Busca as configurações do banco de dados, para sabermos o que devemos fazer.
            JobsList = GenerateFakeJobs();
        }
    }
}
