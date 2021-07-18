using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Application.DTOs
{
	public class WorkerServicesDTO
	{
		public Guid WorkerId { get; set; }
		public List<ServiceDetailsDTO> ServiceDetails { get; set; }
	}
}
