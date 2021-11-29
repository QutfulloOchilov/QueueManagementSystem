using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
    public class User : Person
    {
        public User()
        {
            Reservations = new List<HaircutReservation>();
            Feedbacks = new List<Feedback>();
            JobDetails = new List<JobDetail>();
        }

        public virtual List<HaircutReservation> Reservations { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<JobDetail> JobDetails { get; set; }
    }
}