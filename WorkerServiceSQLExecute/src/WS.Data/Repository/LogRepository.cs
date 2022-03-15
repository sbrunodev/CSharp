using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Interfaces;
using WS.Business.Models;

namespace WS.Data.Repository
{
    public class LogRepository
    {
        private readonly IMongoCollection<Job> _jobs;

        public LogRepository(IJobSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _jobs = database.GetCollection<Job>(settings.JobCollectionName);
        }

        public List<Job> Get() => _jobs.Find(job => true).ToList();

        public Job Get(int id) => _jobs.Find(job => job.Id == id).FirstOrDefault();

        public Job Create(Job job)
        {
            _jobs.InsertOne(job);
            return job;
        }

        public void Update(int id, Job updatedJob) => _jobs.ReplaceOne(job => job.Id == id, updatedJob);

        public void Delete(Job jobForDeletion) => _jobs.DeleteOne(job => job.Id == jobForDeletion.Id);

        public void Delete(int id) => _jobs.DeleteOne(job => job.Id == id);
    }
}