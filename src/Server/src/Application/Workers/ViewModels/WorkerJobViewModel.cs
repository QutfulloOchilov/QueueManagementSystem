using System;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
    public class WorkerJobViewModel
    {
        public Guid JobDetailId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
    }
}