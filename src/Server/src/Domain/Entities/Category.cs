using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            Jobs = new List<Job>();
        }

        public string Name { get; set; }
        public virtual List<Job> Jobs { get; set; }
    }
}
