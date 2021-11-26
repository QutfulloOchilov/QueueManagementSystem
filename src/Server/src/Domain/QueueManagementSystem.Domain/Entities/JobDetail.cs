using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
    public class JobDetail : EntityBase
    {
        public JobDetail()
        {
            Users = new List<User>();
            HaircutReservations = new List<HaircutReservation>();
        }

        public virtual Job Job { get; set; }
        public Guid JobId { get; set; }
        public virtual Worker Worker { get; set; }
        public Guid WorkerId { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<HaircutReservation> HaircutReservations { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}