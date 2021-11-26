using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.WorkerSchedules.QueryModels;
using QueueManagementSystem.Application.WorkerSchedules.QueryModels.Common;
using QueueManagementSystem.Application.WorkerSchedules.QueryModels.Insert;
using QueueManagementSystem.Application.WorkerSchedules.Services;
using QueueManagementSystem.Application.WorkerSchedules.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.API.Controllers
{
    public class WorkerScheduleController : BaseController<WorkerSchedule, WorkerScheduleViewModel,
        WorkerScheduleBaseQueryModel, IWorkerScheduleService>
    {
        public WorkerScheduleController(IWorkerScheduleService service) : base(service)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerScheduleViewModel>> GetById(Guid id)
        {
            return Ok(await GetEntityById(id));
        }

        [HttpGet("getSchedules/{workerId}")]
        public async Task<ActionResult<IEnumerable<WorkerScheduleViewModel>>> GetShedules(Guid workerId)
        {
            return Ok(await Service.GetWorkerSchedule(workerId));
        }

        [HttpPost]
        public async Task<ActionResult<WorkerScheduleViewModel>> Create([FromBody] InsertWorkerScheduleQueryModel model)
        {
            return Ok(await base.Create(model));
        }

        [HttpPut]
        public async Task<ActionResult<WorkerScheduleViewModel>> Update([FromBody] WorkerScheduleQueryModel model)
        {
            return Ok(await base.Update(model));
        }
    }
}