using System;

namespace QueueManagementSystem.Application.Users.QueryModels
{
    public class CancelReservationQueryModel
    {
        public Guid UserId { get; set; }
        public Guid ReservationId { get; set; }
    }
}