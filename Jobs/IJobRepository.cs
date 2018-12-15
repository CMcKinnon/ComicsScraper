using ComicsScraper.Models;
using System;
using System.Collections.Generic;

namespace ComicsScraper.Jobs
{
    public interface IJobRepository
    {
        void AddJob(Job job);
        Job GetJob();
        Job GetJobStatus(DateTime date);
        List<Job> GetAllJobs();
    }
}
