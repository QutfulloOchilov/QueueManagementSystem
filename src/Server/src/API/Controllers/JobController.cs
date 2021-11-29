using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Jobs.QueryModels;
using QueueManagementSystem.Application.Jobs.QueryModels.Common;
using QueueManagementSystem.Application.Jobs.QueryModels.Insert;
using QueueManagementSystem.Application.Jobs.Services;
using QueueManagementSystem.Application.Jobs.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.API.Controllers
{
    public class JobController : BaseController<Job, JobViewModel, JobBaseQueryModel, IJobService>
    {
        public JobController(IJobService service) : base(service)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobViewModel>> GetById(Guid id)
        {
            return Ok(await GetEntityById(id));
        }

        [HttpPost]
        public async Task<ActionResult<JobViewModel>> Create([FromBody] InsertJobQueryModel model)
        {
            return Ok(await base.Create(model));
        }

        [HttpPut]
        public async Task<ActionResult<JobViewModel>> Update([FromBody] JobQueryModel model)
        {
            return Ok(await base.Update(model));
        }
    }
}