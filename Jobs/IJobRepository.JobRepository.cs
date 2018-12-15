using ComicsScraper.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ComicsScraper.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly BlockingCollection<Job> jobs;

        public JobRepository()
        {
            jobs = new BlockingCollection<Job>();
        }

        public void AddJob(Job job)
        {
            if (jobs.FirstOrDefault(j => j.JobId == job.JobId) == null)
            {
                jobs.Add(job);
            }
        }

        public Job GetJob() => jobs.Take();

        public Job GetJobStatus(DateTime date) => jobs.FirstOrDefault(j => j.JobId == date.ToString("yyyy-MM-dd"));

        public List<Job> GetAllJobs() => jobs.Select(j => j).ToList();
    }
}
