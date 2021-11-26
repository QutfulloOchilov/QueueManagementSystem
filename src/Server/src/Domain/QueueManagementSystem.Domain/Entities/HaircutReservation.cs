using System;

namespace QueueManagementSystem.Domain.Entities
{
    public class HaircutReservation : EntityBase
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual JobDetail JobDetail { get; set; }
        public Guid JobDetailId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}