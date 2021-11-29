using System;

namespace QueueManagementSystem.Application.Users.QueryModels
{
    public class GetFreeTimeQueryModel
    {
        public Guid WorkerId { get; set; }
        public Guid JobId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}