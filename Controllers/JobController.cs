using ComicsScraper.Constants;
using ComicsScraper.Jobs;
using ComicsScraper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ComicsScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        [HttpGet]
        public ActionResult<List<Job>> GetJobs()
        {
            return jobRepository.GetAllJobs();
        }

        [HttpGet("{date}")]
        public ActionResult<Job> GetJobStatus(DateTime date)
        {
            Job job = jobRepository.GetJobStatus(date);
            if (job == null)
            {
                return NotFound();
            }
            return job;
        }

        [HttpPost("{date}")]
        public ActionResult<Job> CreateJob(DateTime date)
        {
            Job job = new Job
            {
                JobId = date.ToString("yyyy-MM-dd"),
                Created = DateTime.Now,
                Status = JobStatus.Pending,
                PercentComplete = 0
            };
            jobRepository.AddJob(job);
            return job;
        }
    }
}