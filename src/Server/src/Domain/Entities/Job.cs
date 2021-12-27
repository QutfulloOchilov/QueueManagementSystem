using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
    public class Job : EntityBase
    {
        public Job()
        {
            JobDetails = new List<JobDetail>();
            Workers = new List<Worker>();
        }

        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<JobDetail> JobDetails { get; set; }
        public virtual List<Worker> Workers { get; set; }
    }
}